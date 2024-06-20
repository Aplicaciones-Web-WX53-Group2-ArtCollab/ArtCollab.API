using Domain.Monetization.Model.Aggregates;
using Domain.Shared.Repositories;

namespace Domain.Monetization.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription> 
{
    Task<IEnumerable<Subscription?>> GetAllActiveAsync(bool isActive);
}