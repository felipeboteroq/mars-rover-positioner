namespace MarsRoverPositioner.Business.Services
{
    /// <summary>
    /// Interface for implementing the validation service
    /// </summary>
    public interface IValidator
    {
        bool IsValidBoundary(string entry);
        bool IsValidHeading(string entry);
        bool IsValidInstructionSet(string entry);
        bool IsValidPosition(string entry, int boundary);
    }
}