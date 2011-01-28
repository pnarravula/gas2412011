 using System;
 using System.Collections.Generic;
 using System.IO;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class ConfigurationFileReaderSpecs
    {
        public abstract class concern : Observes<ConfigurationFileReader>
        {
        
        }

        [Subject(typeof(ConfigurationFileReader))]
        public class when_observation_name : concern
        {
            Establish c = () =>
            {
                configurated_command_types = new List<Type> {typeof(Dummy1), typeof(Dummy2)};
                configurated_command_type_names = new List<string> {"Dummy1", "Dummy2"};
                using(FileStream configure_file = File.OpenWrite())
                {
                    configure_file.Write();
                }

            };

            class Dummy2
            {
            }

            class Dummy1
            {
            }

            Because b = () =>
               result  =  sut.read_file("startup_pipeline.txt.template");

            It should_read_configuration_file_reader = () =>
            {
                result.ShouldContainOnly(configurated_command_types);
            };

            static List<Type> configurated_command_types;
            static List<Type> result;
            static List<string> configurated_command_type_names;
        }
    }
}
