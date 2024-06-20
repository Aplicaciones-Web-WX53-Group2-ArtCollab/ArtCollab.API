using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;

namespace Application.Monetization.Internal.QueryServices;

public class SubscriptionQueryService(ISubscriptionRepository subscriptionRepository) : ISubscriptionQueryService
{
    public async Task<IEnumerable<Subscription?>> Handle(GetAllSubscriptionsQuery query)
    {
        return await subscriptionRepository.GetAllAsync();
    }

    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
    {
        return await subscriptionRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Subscription?>> Handle(GetAllSubscriptionsActiveQuery query)
    {
        return await subscriptionRepository.GetAllActiveAsync(true);
    }
}