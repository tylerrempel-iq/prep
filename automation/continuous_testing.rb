module Automation
  class ChangedFile
    attr_accessor :name,:last_changed_time

    def initialize(name)
      @name = name
      @last_changed_time = last_time_changed
    end

    def last_time_changed
      File.mtime(@name)
    end

    def has_changed?
      @last_changed_time < last_time_changed
    end

    def update
      @last_changed_time = last_time_changed
    end

    def was_deleted?
      not File.exists?(@name)
    end
  end


  class BuildMessage
    def initialize(error_items)
      @error_items = error_items
    end

    def successful
      @error_items.length == 0
    end

    def message
      successful ? "Build Successful" : @error_items.join("\r\n")
    end
  end


  class ContinuousTesting < Thor
    include ::Automation::Compile::CompileUnitResolution
    namespace :continuous_testing

    attr_reader :compile_unit,
                :compile_file

    desc 'run_it', 'start the continuous tester'
    def run_it(compile_file)
      @compile_unit = get_compile_unit(compile_file)
      @compile_file = compile_file

      while true do
        monitor
        sleep(settings.specs.continuous_testing.interval)
      end
    end

    no_commands do
      def all_files
        @all_files ||= {}
      end

      def scan_for_new_files
        has_new_files = false

        settings.specs.continuous_testing.glob.call().each do|file|
          unless (all_files.key?(file))
            has_new_files = true
            all_files[file] = ChangedFile.new(file)
          end
        end

        has_new_files
      end

      def remove_all_deleted
        remaining = all_files.select{|path,item| ! item.was_deleted?}
        files_were_deleted = remaining.length != all_files.length
        @all_files = remaining
        files_were_deleted
      end

      def changes_have_occured
        return scan_for_new_files | remove_all_deleted | files_have_changed
      end

      def files_have_changed
        has_changed = false
        all_files.each do|path,file|
          has_changed |= file.has_changed?
          file.update
        end
        return has_changed
      end

      def get_errors_in(output)
        error_pattern = settings.specs.error_patterns
        result = output.split("\n").select do |item|
          settings.specs.is_build_error.call(item)
        end
        result
      end

      def notify(build_message)
        icon = build_message.successful ? "green" : "red"
        args = {:t => "Build",:i => ".\\#{icon}.jpg"}
        command_line = "automation/tools/growl/growlnotify.exe"
        args.each {|key,value| command_line += " /#{key}:\"#{value}\""}
        `#{command_line} "#{build_message.message}"`
      end

      def monitor
        if changes_have_occured
          build_output = settings.specs.continuous_testing.runner.call(compile_file)
          File.open('build_output','w') do|file|
            file << build_output
          end
          errors = get_errors_in(build_output)
          notify(BuildMessage.new(errors))
        end
      end
    end
  end
end
