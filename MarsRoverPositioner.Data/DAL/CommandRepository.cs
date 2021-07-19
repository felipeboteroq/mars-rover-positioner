using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPositioner.Data.DAL
{
    /// <summary>
    /// Repository that persists the command logs
    /// </summary>
    public class CommandRepository : ICommandRepository
    {
        private IDataContext context;

        public CommandRepository(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<CommandLogEntry> GetLogs()
        {
            return context.Logs.ToList();
        }

        public void InsertLog(string commandName, string commandResult)
        {
            context.Logs.Add(new CommandLogEntry { Name = commandName, Result = commandResult });
        }

        public void Clean()
        {
            context.Logs.Clear();
        }

    }
}
