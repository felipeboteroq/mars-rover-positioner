using System;
using MarsRoverPositioner.Business.Entities;
using MarsRoverPositioner.Business.Commands;
using MarsRoverPositioner.Data.DAL;
using System.Collections.Generic;

namespace MarsRoverPositioner.Business.Services
{
    /// <summary>
    /// The Invoker class, acts as a service that allows the rover to navigate along the grid
    /// </summary>
    public class Navigator : INavigator
    {
        private Command _command;

        private Rover _rover;

        private Grid _grid;

        private ICommandRepository _repository;

        public Location LastLocation {
            get
            { 
                return _rover.CurrentLocation; 
            }                 
        }

        public Navigator(ICommandRepository repository)
        {
            _repository = repository;
        }

        public void ReInit()
        {
            _repository.Clean();
        }

        public IEnumerable<CommandLogEntry> GetSummary()
        {
            return _repository.GetLogs();
        }

        public void SetRover(Rover rover)
        {
            _rover = rover;
        }

        public void SetGrid(Grid grid)
        {
            _grid = grid;
        }


        public void SetCommand(char commandOption)
        {
            _command = new CommandFactory().GetCommand(commandOption);
        }

        public void ExecuteCommand()
        {
            if (_rover == null || _command == null || _grid == null)
            {
                throw new Exception("Please set rover, grid and command before trying to execute.");
            }
            _rover.ExecuteCommand(_command, _grid);            
            _repository.InsertLog(_command.GetType().Name, _command.Result);
        }
    }

}
