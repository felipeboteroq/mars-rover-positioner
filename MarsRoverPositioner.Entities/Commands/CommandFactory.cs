
namespace MarsRoverPositioner.Business.Commands
{
    public class CommandFactory
    {
        //Factory method to get the command depending on the character in the instruction set
        public Command GetCommand(char commandOption)
        {
            switch (commandOption)
            {
                case 'R':
                    return new RotateRigthCommand();
                case 'L':
                    return new RotateLeftCommand();
                case 'M':
                    return new MoveForwardCommand();
                default:
                    return new InvalidCommand();
            }
        }
    }
}
