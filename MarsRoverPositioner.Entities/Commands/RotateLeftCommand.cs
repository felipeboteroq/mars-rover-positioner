using System;
using MarsRoverPositioner.Business.Entities;

namespace MarsRoverPositioner.Business.Commands
{
    /// <summary>
    /// A concrete command for rotating left the rover in the grid
    /// </summary>
    public class RotateLeftCommand : Command
    {
        public override void Execute(Location location, Grid grid)
        {
            
            switch (location.Heading)
            {
                case 'N':
                    location.Heading = 'W';
                    break;
                case 'E':
                    location.Heading = 'N';
                    break;
                case 'S':
                    location.Heading = 'E';
                    break;
                case 'W':
                    location.Heading = 'S';
                    break;
                default:
                    throw new Exception("Invalid heading can't rotate");
            }

            Result = location.ToString();
        }
    }
}
