namespace Shared;

public class AccountAlreadyExistsException : Exception
{
    public AccountAlreadyExistsException() : base("This account already exists")
    {
        
    }
}