using Domain.Shared.Repositories;
using Domain.User.Model.Aggregates;

namespace Domain.User.Repositories;

public interface IReaderRepository : IBaseRepository<Reader>
{
    bool ReaderExistsByEmailAndPassword(string email, string password);
    bool ReaderExistsByUsername(string username);
    
    Task<IEnumerable<Reader?>> GetAllReadersByType(string type);
}