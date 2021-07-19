using System.Linq;
using MarsRoverPositioner.Data.DAL;

namespace MarsRoverPositioner.Business.Services
{
    /// <summary>
    /// Provides a service for validation of the user inputs prior to starting the execution of each task.
    /// </summary>
    public class Validator : IValidator
    {

        private char[] validHeadings = new char[] { 'N', 'E', 'S', 'W' };
        private char[] validInstructions = new char[] { 'R', 'L', 'M' };

        public Validator()
        {

        }

        public bool IsValidBoundary(string entry)
        {
            int number;
            var isNumeric = int.TryParse(entry, out number);
            return isNumeric && number > 1;
        }

        public bool IsValidPosition(string entry, int boundary)
        {
            int number;
            var isNumeric = int.TryParse(entry, out number);
            return isNumeric && number >= 0 && number < boundary;
        }

        public bool IsValidHeading(string entry)
        {
            if (entry.Length > 1)
            {
                return false;
            }

            var heading = (char)entry[0];

            if (!validHeadings.Contains(heading))
            {
                return false;
            }

            return true;
        }

        public bool IsValidInstructionSet(string entry)
        {
            var chars = entry.ToCharArray();
            var invalidInstructionsCount = chars.Where(e => !validInstructions.Contains(e)).Count();
            return invalidInstructionsCount == 0;
        }
    }

}
