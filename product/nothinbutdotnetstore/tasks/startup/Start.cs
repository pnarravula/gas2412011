using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static Func<StartupCommandFactory> command_factory_provider = () =>
            new StartupCommandFactory(null);

        public static Func<string, List<StartupCommand>> configuration_file_reader = (configuration_file) =>
            new ConfigurationFileReader(configuration_file).Read();
        
        
        public static StartupCommandPipelineBuilder by<CommandType>() where CommandType : StartupCommand
        {
            return new StartupCommandPipelineBuilder(new List<StartupCommand>()
                                                     , command_factory_provider());
        }

        public static StartupCommandPipelineBuilder by_running_all_commands_in(string startup_pipeline_txt_template)
        {
            return new StartupCommandPipelineBuilder(configuration_file_reader(startup_pipeline_txt_template)
                                                     , command_factory_provider());
        }
    }

    public class ConfigurationFileReader
    {
        readonly string configuration_file;

        public ConfigurationFileReader(string configuration_file)
        {
            this.configuration_file = configuration_file;
            
        }

        internal List<StartupCommand> Read()
        {
 	        throw new NotImplementedException();
        }
    }
}