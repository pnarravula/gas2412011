using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class StartSpecs
    {
        public abstract class concern : Observes<StartRunning>
        {
        }

        public class when_finishing_the_command_pipeline : concern
        {
            Establish c = () =>
            {
                provider = an<ComponentRegistrationProvider>();
                startup_command_factory = new StartupCommandFactory(provider);
                all_commands_in_pipeline = Enumerable.Range(1, 100).Select(x => an<StartupCommand>()).ToList();
                provide_a_basic_sut_constructor_argument(all_commands_in_pipeline);
                provide_a_basic_sut_constructor_argument(startup_command_factory);
            };

            Because b = () =>
                sut.finish_by<OurStartupCommand>();


            It should_add_the_last_command_to_the_list_of_commands_to_run_in_the_last_position = () =>
                all_commands_in_pipeline.Last().ShouldBeAn<OurStartupCommand>();


            It should_call_run_on_each_of_the_commands_in_the_pipeline = () =>
            {
                all_commands_in_pipeline.Take(all_commands_in_pipeline.Count() - 1).each(x => x.received(y => y.run()));

            };

            static IList<StartupCommand> all_commands_in_pipeline;
            static StartupCommandFactory startup_command_factory;
            static ComponentRegistrationProvider provider;
        }
    }

    public class OurStartupCommand : StartupCommand
    {
        ComponentRegistrationProvider provider;

        public OurStartupCommand(ComponentRegistrationProvider provider)
        {
            this.provider = provider;
        }

        public void run()
        {
        }
    }
}