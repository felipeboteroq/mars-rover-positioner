using MarsRoverPositioner.Business.Entities;
using MarsRoverPositioner.Data.DAL;
using System.Collections.Generic;

namespace MarsRoverPositioner.Business.Services
{
    /// <summary>
    /// Interface for implementing the navigation service
    /// </summary>
    public interface INavigator
    {
        void ExecuteCommand();
        IEnumerable<CommandLogEntry> GetSummary();
        void ReInit();
        void SetCommand(char commandOption);
        void SetGrid(Grid grid);
        void SetRover(Rover rover);
        Location LastLocation { get; }
    }
}