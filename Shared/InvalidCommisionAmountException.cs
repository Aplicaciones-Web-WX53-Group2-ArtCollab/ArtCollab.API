namespace Shared;

public class InvalidCommisionAmountException : Exception
{
    public InvalidCommisionAmountException() : base("Amount must be greater than 0")
    {
    }
}