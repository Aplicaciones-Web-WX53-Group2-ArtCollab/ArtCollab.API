using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities;

public class SubscriptionManager(ISubscriptionStrategy strategy)
{
    public void SetSubscriptionStrategy(ISubscriptionStrategy subscriptionStrategy)
    {
        strategy = subscriptionStrategy;
    }
    
}