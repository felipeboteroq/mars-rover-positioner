using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPositioner.Data.DAL
{
    /// <summary>
    /// Stores the name and result of a command
    /// </summary>
    public class CommandLogEntry
    {
        public string Name { get; set; }
        public string Result { get; set; }
        public override string ToString()
        {
            return $"Command: {Name}, result: {Result}\n -------------------------------------";
        }
    }
}
