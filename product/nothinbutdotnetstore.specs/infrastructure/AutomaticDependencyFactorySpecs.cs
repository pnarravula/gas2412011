using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.specs.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class AutomaticDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            AutomaticDependencyFactory>
        {
        }

        [Subject(typeof(AutomaticDependencyFactory))]
        public class when_creating_a_dependency : concern
        {
            Establish c = () =>
            {
                container = the_dependency<DependencyContainer>();
                constructor =
                    ExpressionUtility.get_constructor(() => new ComponentWithLotsOfDependencies(null, null, null));
                constructor_selection_strategy = the_dependency<ConstructorSelection>();

                the_sql_connection = new SqlConnection();
                the_command = new SqlCommand();
                the_other_dependency = new OtherDependency();
                container.Stub(x => x.a(typeof(IDbConnection))).Return(the_sql_connection);
                container.Stub(x => x.a(typeof(IDbCommand))).Return(the_command);
                container.Stub(x => x.a(typeof(OtherDependency))).Return(the_other_dependency);
                constructor_selection_strategy.Stub(
                    x => x.get_applicable_constructor_on(typeof(ComponentWithLotsOfDependencies)))
                    .Return(constructor);
                provide_a_basic_sut_constructor_argument(typeof(ComponentWithLotsOfDependencies));
            };

            Because b = () =>
                result = sut.create();

            It should_create_the_dependency_with_all_of_its_dependencies_provided = () =>
            {
                var item = result.ShouldBeAn<ComponentWithLotsOfDependencies>();
                item.connection.ShouldEqual(the_sql_connection);
                item.command.ShouldEqual(the_command);
                item.other.ShouldEqual(the_other_dependency);
            };

            static object result;
            static SqlConnection the_sql_connection;
            static IDbCommand the_command;
            static OtherDependency the_other_dependency;
            static DependencyContainer container;
            static ConstructorSelection constructor_selection_strategy;
            static ConstructorInfo constructor;
        }
    }

    class ComponentWithLotsOfDependencies
    {
        public OtherDependency other;

        public IDbConnection connection { get; set; }

        public IDbCommand command { get; set; }

        public ComponentWithLotsOfDependencies(IDbConnection connection, IDbCommand command)
        {
            this.other = other;
            this.connection = connection;
            this.command = command;
        }

        public ComponentWithLotsOfDependencies(OtherDependency other, IDbConnection connection, IDbCommand command)
            : this(connection, command)
        {
            this.other = other;
        }
    }

    class OtherDependency
    {
    }
}