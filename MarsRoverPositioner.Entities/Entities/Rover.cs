using System;
using MarsRoverPositioner.Business.Commands;

namespace MarsRoverPositioner.Business.Entities
{
    /// <summary>
    /// The receiver of the commands invoked by navigator, will move along the grid.
    /// </summary>
    public class Rover
    {
        public Location CurrentLocation { get; set; }

        public Rover(int x, int y, char heading)
        {
            this.CurrentLocation = new Location() { X = x, Y = y, Heading = heading };
        }

        public void ExecuteCommand(Command command, Grid grid)
        {
            command.Execute(CurrentLocation, grid);
        }

    }
}
