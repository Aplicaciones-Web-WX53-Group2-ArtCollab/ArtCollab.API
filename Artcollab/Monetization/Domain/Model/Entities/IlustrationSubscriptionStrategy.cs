using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities;

public class IlustrationSubscriptionStrategy : ISubscriptionStrategy
{
    public void Subscribe(Subscription subscription)
    {
        subscription.IsActive = true;
    }
    
}