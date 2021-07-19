using System;
using MarsRoverPositioner.Business.Entities;


namespace MarsRoverPositioner.Business.Commands
{
    /// <summary>
    /// A concrete command for moving forward one unit on the grid
    /// </summary>
    public class MoveForwardCommand : Command
    {
        public override void Execute(Location location, Grid grid)
        {

            switch (location.Heading)
            {
                case 'N':
                    location.Y++;
                    break;
                case 'E':
                    location.X++;
                    break;
                case 'S':
                    location.Y--;
                    break;
                case 'W':
                    location.X--;
                    break;
                default:
                    throw new Exception("Invalid heading can't move");
            }

            if (location.X >= grid.XBoundary || 
                location.Y >= grid.YBoundary ||
                location.X < 0 ||
                location.Y < 0 )
            {
                Result = $"WARNING: Movement out of bounds: {location}";
                return;
            }

            Result = location.ToString();
        }
    }
}
