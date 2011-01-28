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

	public class DefaultRegistrationProvider : ComponentRegistrationProvider
	{

		public void register<Contract, Implementation>()
		{
			return;
		}

		public void register<Implementation>()
		{
			return;
		}

		public void register_instance<Contract>(Contract contract)
		{
			return;
		}

		public IDictionary<Type, DependencyFactory> raw_factories
		{
			get { throw new NotImplementedException(); }
		}
	}

}