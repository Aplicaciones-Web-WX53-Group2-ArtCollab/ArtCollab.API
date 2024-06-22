namespace Shared;

public class ErrorOcurredWhileCreatingUserException : Exception
{
    public ErrorOcurredWhileCreatingUserException(string message): base(message)
    {
    }
}