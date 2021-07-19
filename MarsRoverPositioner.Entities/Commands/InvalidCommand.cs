using System;
using MarsRoverPositioner.Business.Entities;

namespace MarsRoverPositioner.Business.Commands
{
    /// <summary>
    /// A concrete command used in case an invalid instruction is received and not catched by the validation
    /// </summary>
    public class InvalidCommand : Command
    {
        public override void Execute(Location location, Grid grid)
        {
            Result = "Invalid Command, will be ignored";
        }
    }
}
