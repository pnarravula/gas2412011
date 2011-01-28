using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface ComponentRegistrationProvider
    {
        void register<Contract, Implementation>();
        void register<Implementation>();
        void register_instance<Contract>(Contract contract);
        IDictionary<Type, DependencyFactory> raw_factories { get; }
    }
}