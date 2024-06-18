using Infrastructure.Shared.Interfaces;
using Infrastructure.Users.Model;

namespace Infrastructure.Users.Interfaces;

public interface IReaderData : IRepository<Reader>
{
    Task<Reader?> GetByUserNameAsync(string userName);
    Task<Reader> GetByEmailAsync(string email);
    Task<int?> GetByEmailAndPasswordAsync(string email, string password);
}