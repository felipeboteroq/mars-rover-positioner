using System.Collections.Generic;

namespace MarsRoverPositioner.Data.DAL
{
    /// <summary>
    /// Interface describing the data context
    /// </summary>
    public interface IDataContext
    {
        IList<CommandLogEntry> Logs { get; set; }
    }
}