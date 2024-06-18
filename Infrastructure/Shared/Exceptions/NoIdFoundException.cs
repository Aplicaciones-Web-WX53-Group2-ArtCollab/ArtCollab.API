namespace Infrastructure.Shared.Exceptions;

public class NoIdFoundException : Exception
{
    public NoIdFoundException(string message) : base(message)
    {
    }
    
    public NoIdFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}