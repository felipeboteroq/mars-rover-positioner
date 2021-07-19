using MarsRoverPositioner.Business.Entities;

namespace MarsRoverPositioner.Business.Commands
{
    /// <summary>
    /// The Command abstract class
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute(Location location, Grid grid);
        public string Result { get; set; }
    }
}
