require_relative 'utils/string'
require_relative 'utils/unique_files'
require_relative 'utils/nested_message'
require_relative 'utils/file_digest'
require_relative 'utils/timestamp_set'

module Automation
  module Utils
    extend self

    def self.included(base)
      base.class_option :log, default: false
      base.class_option :dry_run, default: false
    end

    def clean_invoke(command)
      invoke command, [], {}
    end

    def log?
      options[:log]
    end

    def log(message)
      NestedMessage.display(message) if log?
    end

    def section(name)
      log "=" * 70
      log name
      log "=" * 70
    end

    def banner(title)
      NestedMessage.nest do
        section("START - #{title}")
        yield
        section("END - #{title}")
      end
    end

    def get_lines_of_code(bash_code)
      bash_code.split("\n")
    end

    def default_exec_options
      options = {
        title: 'Running Script',
        batch: false
      }
    end

    def run_command_lines(exec_options={}, code=nil)
      options = default_exec_options.merge(exec_options)
      exec(*get_lines_of_code(code), options)
    end

    def batch_run(lines)
      exec_line(lines.join(";"))
    end

    def linear_run(lines)
      lines.each do |line|
        exec_line(line)
      end
    end

    def exec_line(line)
      line = line.gsub(/;;/, ";")
      log "Running...: #{line}"
      system(line) unless options[:dry_run]
    end

    def pick_item_from(items,prompt)
      items.each_with_index{|item,index| p "#{index + 1} - #{item}"}
      index = ask(prompt).to_i
      return index == 0 ? "": items[index-1]
    end

    def exec(*lines, options)
      options = default_exec_options.merge(options)
      runner = options[:batch] ? :batch_run : :linear_run
      banner(options[:title]) do
        banner('Running Script.....') do
          NestedMessage.nest do
            lines.each do |line|
              log line
            end
            log "\n"
            send(runner, lines)
          end
        end
      end
    end
  end
end

