using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Shared.Domain.Repositories;

namespace Application.Monetization.Domain.Repository;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task<IEnumerable<Subscription>> finbyIsActive(bool isActive);
    Task<IEnumerable<Subscription>> finbyIsNotActive(bool isActive);
}