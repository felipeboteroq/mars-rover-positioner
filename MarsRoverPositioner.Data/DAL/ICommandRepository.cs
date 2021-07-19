using System.Collections.Generic;

namespace MarsRoverPositioner.Data.DAL
{
    /// <summary>
    /// Interface for implementing the command repository
    /// </summary>
    public interface ICommandRepository
    {
        IEnumerable<CommandLogEntry> GetLogs();
        void InsertLog(string commandName, string commandResult);
        void Clean();
    }
}