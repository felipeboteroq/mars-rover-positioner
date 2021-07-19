using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPositioner.Data.DAL
{
    /// <summary>
    /// Simple class that stores the results of the commands
    /// </summary>
    public class DataContext : IDataContext
    {
        public IList<CommandLogEntry> Logs { get; set; }

        public DataContext()
        {
            this.Logs = new List<CommandLogEntry>();
        }

    }
}
