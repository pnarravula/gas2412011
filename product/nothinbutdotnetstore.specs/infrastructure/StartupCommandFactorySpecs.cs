 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class StartupCommandFactorySpecs
    {
        public abstract class concern : Observes<StartupCommandFactory>
        {
        
        }

        [Subject(typeof(StartupCommandFactory))]
        public class when_creating_a_startup_command_from_a_type : concern
        {
            Establish c = () =>
            {
                the_provider = new FakeProvider();
                provide_a_basic_sut_constructor_argument(the_provider);
            };


            Because b = () =>
                result = sut.create_from(typeof(NewStartupCommand));


            It should_return_an_instance_of_the_command_with_its_required_details = () =>
            {
                result.ShouldBeAn<NewStartupCommand>()
                    .component_provider.ShouldEqual(the_provider);
            };

            static StartupCommand result;
            static ComponentRegistrationProvider the_provider;
        }
    }

    class FakeProvider : ComponentRegistrationProvider
    {
        public void register<Contract, Implementation>()
        {
            throw new NotImplementedException();
        }

        public void register<Implementation>()
        {
            throw new NotImplementedException();
        }

        public void register<Contract>(Contract contract)
        {
            throw new NotImplementedException();
        }
    }

    class NewStartupCommand : StartupCommand
    {
        public NewStartupCommand(ComponentRegistrationProvider component_provider)
        {
            this.component_provider = component_provider;
        }

        public void run()
        {
            throw new NotImplementedException();
        }

        public ComponentRegistrationProvider component_provider { get; set; }
    }
}
