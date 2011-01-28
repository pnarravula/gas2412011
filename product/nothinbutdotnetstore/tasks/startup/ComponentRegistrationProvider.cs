namespace nothinbutdotnetstore.tasks.startup
{
    public interface ComponentRegistrationProvider
    {
        void register<Contract, Implementation>();
        void register<Implementation>();
        void register<Contract>(Contract contract);
    }
}