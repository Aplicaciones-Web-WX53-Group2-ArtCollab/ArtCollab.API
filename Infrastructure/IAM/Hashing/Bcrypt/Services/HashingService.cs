using Application.IAM.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;
namespace Infrastructure.IAM.Hashing.Bcrypt.Services;

public class HashingService : IHashingService
{

    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}