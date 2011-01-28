namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            Start.by_running_all_commands_in("startup_pipeline.txt");
        }
    }
}