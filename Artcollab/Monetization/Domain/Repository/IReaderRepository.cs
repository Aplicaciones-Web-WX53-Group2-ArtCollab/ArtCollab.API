using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Shared.Domain.Repositories;

namespace Application.Monetization.Domain.Repository;

public interface IReaderRepository :IBaseRepository<Reader>
{
    Task<IEnumerable<Reader>> FindByUsername(string username);
    Task<IEnumerable<Reader>> FindByType(string type);
    Task<Reader> FindByEmail(string email);
}