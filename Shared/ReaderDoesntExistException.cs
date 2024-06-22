namespace Shared;

public class ReaderDoesntExistException : Exception
{
    public  ReaderDoesntExistException(string message): base(message)
    {
        
    }
}