using System;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface DependencyFactories
    {
        DependencyFactory create_factory(Type contract, Type implementation);
        DependencyFactory create_factory(Type contract);
        DependencyFactory create_factory<Contract>(Contract instance);
    }
}