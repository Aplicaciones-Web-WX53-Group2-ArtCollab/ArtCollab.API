using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IReaderData : IRepository<Reader>
{
    Task<Reader> GetByUserNameAsync(string userName);
    Task<Reader> GetByEmailAsync(string email);
    Task<Reader> GetByEmailAndPasswordAsync(string email, string password);
}