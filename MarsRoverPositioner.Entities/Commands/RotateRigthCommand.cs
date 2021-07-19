using System;
using MarsRoverPositioner.Business.Entities;

namespace MarsRoverPositioner.Business.Commands
{ 
    /// <summary>
    /// A concrete command for rotating rigth the rover on the grid
    /// </summary>
    public class RotateRigthCommand : Command
    {
        public override void Execute(Location location, Grid grid)
        {

            switch (location.Heading)
            {
                case 'N':
                    location.Heading = 'E';
                    break;
                case 'E':
                    location.Heading = 'S';
                    break;
                case 'S':
                    location.Heading = 'W';
                    break;
                case 'W':
                    location.Heading = 'N';
                    break;
                default:
                    throw new Exception("Invalid heading can't rotate");
            }
            Result = location.ToString();
        }
    }
}
