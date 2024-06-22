namespace Shared;

public class InvalidUsernameOrPasswordException : Exception
{
    public InvalidUsernameOrPasswordException() : base("Invalid username or password")
    {
    }
}