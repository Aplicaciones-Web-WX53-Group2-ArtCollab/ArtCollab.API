namespace Infrastructure.Shared.Exceptions;

public class InvalidTypeReaderException : Exception
{
    public InvalidTypeReaderException(string message) : base(message)
    {
    }
    
    public InvalidTypeReaderException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
}