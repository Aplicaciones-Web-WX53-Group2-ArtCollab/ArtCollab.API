using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Queries;

namespace Domain.Monetization.Services;

public interface ISubscriptionQueryService
{
    Task<IEnumerable<Subscription?>> Handle(GetAllSubscriptionsQuery query);
    Task<Subscription?> Handle(GetSubscriptionByIdQuery query);
    Task<IEnumerable<Subscription?>> Handle(GetAllSubscriptionsActiveQuery query);
}