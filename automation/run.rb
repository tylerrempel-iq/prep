module Automation
  class Run < Thor
    include ::Automation::InputUtils
    namespace :run

    method_option :compile_file, default: nil

    desc 'unit', 'Running a compile unit'
    def unit
      compile_unit = options[:compile_file] || pick_item_from(settings.compile_units, "Pick a compile unit to run")
      load compile_unit
      project = settings.compile_unit
      invoke 'compile:project', [compile_unit]
      system("#{project.output}")
    end
  end
end
