using System;
using System.Collections.Generic;
using System.Linq;
namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_command_that_can_run(Request request)
        {
            //var iterator =  all_commands.GetEnumerator();
            //RequestCommand request_command = null;
            //while (iterator.MoveNext())
            //{
            //    request_command = iterator.Current;
            //}
            //return request_command;

            return all_commands.Last();
        }
    }
}