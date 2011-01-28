using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;

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