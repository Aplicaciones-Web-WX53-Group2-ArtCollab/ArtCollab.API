using Application.Monetization.Domain.Model.Aggregates;
using artcollab.API.Monetization.Interfaces.REST;

namespace Application.Monetization.Domain.Model.Entities;

public class IlustrationSubscriptionStrategy : ISubscriptionStrategy
{
    public void Subscribe(Subscription subscription)
    {
        subscription.IsActive = true;
    }
}