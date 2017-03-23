module Automation
  class Bootstrap < Thor
    include ::Automation::Utils

    namespace :bootstrap

    desc 'setup', 'init the machine'
    def setup

      p "entered setup"

      initialize_settings_file

      clean_invoke 'automation:expand'
      clean_invoke 'paket:get_latest_version'
      clean_invoke 'paket:install'

    end

    no_commands do
      def initialize_settings_file
        clean_invoke 'automation:clean'
      end
    end
  end
end
