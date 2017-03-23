module Automation
  module Compile
    class Compile < Thor
      include ::Automation::InputUtils
      include ::Automation::Compile::CompileUnitResolution
      namespace :compile

      desc 'rebuild', 'rebuilds the project'
      def rebuild
        invoke 'automation:init'

        settings.build_order.each do |file|
          project file
        end
      end

      desc 'selection', 'compiles the selected project'
      def selection
        invoke 'automation:init'
        compile_unit = pick_item_from(settings.compile_units, "Pick a compile unit to run")
        project compile_unit
      end

      desc 'project', 'compiles a project'
      def project(compile_file)
        invoke 'automation:init', [] unless Dir.exist?(settings.response_files_dir)
        unit = get_compile_unit(compile_file)
        compile_dependent_projects(unit)
        CSC.run(unit)
      end

      desc 'web', 'compiles a web project'
      def web(web_file)
        invoke 'automation:init', []
        unit = get_compile_unit(web_file)
        source_folder = unit.source_path

        FileUtils.mkdir_p unit.intermediary_path
        FileUtils.mkdir_p File.join(unit.intermediary_path,"dist","assets")
        intermediary_path = unit.intermediary_path

        # FileUtils.cp_r(File.join(source_folder, "dist"), intermediary_path)
        FileUtils.cp_r(File.join(source_folder, "Global.asax"), intermediary_path)
        FileUtils.cp_r(File.join(source_folder, "Global.asax.cs"), intermediary_path)

        settings.config_files.each do |file|
          FileUtils.cp(file, intermediary_path)
        end

        bin_folder = File.join(intermediary_path, "bin")

        FileUtils.mkdir_p bin_folder unless Dir.exist?(bin_folder)

        settings.libs.each do |file|
          FileUtils.cp(file, bin_folder)
        end

        compile_dependent_projects unit
        AspNetCompiler.run(unit)
      end

      no_commands do
        def compile_dependent_projects(project)
          return unless project.dependent_compiles
          project.dependent_compiles.each do |file|
            unit = get_compile_unit(file)
            compile_dependent_projects(unit)
            project(file)
            FileUtils.cp unit.output, settings.web.vs_output_dir
          end
        end
      end
    end
  end
end
