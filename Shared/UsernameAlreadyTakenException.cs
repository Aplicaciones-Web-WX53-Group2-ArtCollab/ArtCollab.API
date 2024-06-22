namespace Shared;

public class UsernameAlreadyTakenException : Exception
{
    public UsernameAlreadyTakenException(string message) : base(message)
    {
    }
}