using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class StartRunningSpecs
    {
        public abstract class concern : Observes<StartupCommandPipelineBuilder>
        {
        }

        public class when_following_with_another_command_to_run : concern
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
                result = sut.then_by<OurStartupCommand>();



            It should_add_the_new_command_to_the_end_of_the_list = () =>
            {
                all_commands_in_pipeline.Last().ShouldBeAn<OurStartupCommand>();
            };

            It should_return_a_start_running_instance_to_continue_the_chain = () =>
                result.ShouldBeAn<StartupCommandPipelineBuilder>().ShouldNotEqual(sut);



            static IList<StartupCommand> all_commands_in_pipeline;
            static StartupCommandFactory startup_command_factory;
            static ComponentRegistrationProvider provider;
            static StartupCommandPipelineBuilder result;
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



            It should_call_run_on_each_of_the_commands_in_the_pipeline = () =>
            {
                all_commands_in_pipeline.Take(all_commands_in_pipeline.Count( ) -1).each(x => x.received(y => y.run()));
                all_commands_in_pipeline.Last().downcast_to<OurStartupCommand>().ran.ShouldBeTrue();
            };

            static IList<StartupCommand> all_commands_in_pipeline;
            static StartupCommandFactory startup_command_factory;
            static ComponentRegistrationProvider provider;
        }
    }

    public class OurStartupCommand : StartupCommand
    {
        public bool ran { get; set; }
        ComponentRegistrationProvider provider;

        public OurStartupCommand(ComponentRegistrationProvider provider)
        {
            this.provider = provider;
        }

        public void run()
        {
            ran = true;

        }
    }
}