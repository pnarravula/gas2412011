using System;
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;
using System.Linq;
namespace nothinbutdotnetstore.specs.infrastructure
{
    public class StartSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Start))]
        public class when_providing_access_to_the_startup_command_pipeline_builder : concern
        {
            Establish c = () =>
            {
                the_factory = new StartupCommandFactory(null);
                Func<StartupCommandFactory> provider = () => the_factory;
                change(() => Start.command_factory_provider).to(provider);
            };
            Because b = () =>
                result = Start.by<TheFirstCommand>();

            It should_return_a_pipeline_builder_constructed_with_the_correct_information =
                () =>
                {
                    result.ShouldNotBeNull();
                    result.startup_command_factory.ShouldEqual(the_factory);
                    result.commands.ShouldNotBeNull();
                };

            static StartupCommandPipelineBuilder result;
            static StartupCommandFactory the_factory;
        }

        [Subject(typeof(Start))]
        public class when_reading_configuration_from_file_and_providing_access_to_the_startup_command_pipeline_builder : concern
        {
            //Parsing a file
            //Read & build the commands in order
            
            //then_by

            Establish c = () =>
            {
                var startup_command_factory = new StartupCommandFactory(null);
                commands = new List<StartupCommand>()
                {
                    startup_command_factory.create_from(typeof(ConfigureCoreComponents)),
                    startup_command_factory.create_from(typeof(ConfigureFrontController))
                };
                
                Start.configuration_file_reader = (file) =>  commands;
                the_factory = new StartupCommandFactory(null);
                Func<StartupCommandFactory> provider = () => the_factory;
                change(() => Start.command_factory_provider).to(provider);
            };

            Because b = () =>
                result = Start.by_running_all_commands_in("startup_pipeline.txt.template");


            It should_have_all_commands =
                () =>
                {
                    result.commands.Select(x=> x.GetType()).ShouldContain(commands);
                };

            
            It should_return_a_pipeline_builder_constructed_with_the_correct_information =
                () =>
                {
                    result.ShouldNotBeNull();
                    result.startup_command_factory.ShouldEqual(the_factory);
                    result.commands.ShouldNotBeNull();
                };

            static List<StartupCommand> commands; 
            static StartupCommandPipelineBuilder result;
            static StartupCommandFactory the_factory;
        }
    }

    class TheFirstCommand : StartupCommand
    {
        ComponentRegistrationProvider provider;

        public TheFirstCommand(ComponentRegistrationProvider provider)
        {
            this.provider = provider;
        }

        public void run()
        {
        }
    }
}