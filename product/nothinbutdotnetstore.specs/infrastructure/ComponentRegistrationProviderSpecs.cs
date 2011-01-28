 using System;
 using System.Collections.Generic;
 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.tasks.startup;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class ComponentRegistrationProviderSpecs
    {
        public abstract class concern : Observes<DefaultComponentRegistrationProvider>
        {
        
        }

        [Subject(typeof(DefaultComponentRegistrationProvider))]
        public class when_registering_a_type_with_both_contract_and_implementation : concern
        {
            Establish c = () =>
            {
                factory = an<DependencyFactory>();
                dependency_factories = the_dependency<DependencyFactories>();
                provide_a_basic_sut_constructor_argument(factories);

                dependency_factories.Stub(x => x.create_factory(typeof(IDbConnection), typeof(SqlConnection)))
                    .Return(factory);
            };

            Because b = () =>
                sut.register<IDbConnection, SqlConnection>();


            It should_register_the_factory_that_can_be_used_to_create_automatic_types = () =>
                sut[typeof(IDbConnection)].ShouldEqual(factory);

            static IDictionary<Type,DependencyFactory> factories;
            static DependencyFactories dependency_factories;
            static DependencyFactory factory;
        }

        [Subject(typeof(DefaultComponentRegistrationProvider))]
        public class when_registering_a_type_with_just_an_implementation_type : concern
        {
            Establish c = () =>
            {
                factory = an<DependencyFactory>();
                dependency_factories = the_dependency<DependencyFactories>();

                dependency_factories.Stub(x => x.create_factory(typeof(IDbConnection)))
                    .Return(factory);
            };

            Because b = () =>
                sut.register<IDbConnection>();


            It should_register_the_factory_using_the_key_of_the_contract= () =>
                sut[typeof(IDbConnection)].ShouldEqual(factory);

            static IDictionary<Type,DependencyFactory> factories;
            static DependencyFactories dependency_factories;
            static DependencyFactory factory;
        }

        public class when_registering_a_type_with_an_implementation_instance : concern
        {
            Establish c = () =>
            {
                factory = an<DependencyFactory>();
                sql_connection = new SqlConnection();
                dependency_factories = the_dependency<DependencyFactories>();

                dependency_factories.Stub(x => x.create_factory(sql_connection))
                    .Return(factory);
            };

            Because b = () =>
                sut.register(sql_connection);


            It should_register_the_factory_using_the_key_of_the_contract= () =>
                sut[typeof(IDbConnection)].ShouldEqual(factory);

            static IDictionary<Type,DependencyFactory> factories;
            static DependencyFactories dependency_factories;
            static DependencyFactory factory;
            static SqlConnection sql_connection;
        }
    }
}
