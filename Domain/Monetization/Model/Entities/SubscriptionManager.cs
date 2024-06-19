using Infrastructure.Monetization.Model.Aggregates;

namespace Infrastructure.Monetization.Model.Entities;

public class SubscriptionManager(ISubscriptionStrategy strategy)
{
    public void SetSubscriptionStrategy(ISubscriptionStrategy subscriptionStrategy)
    {
        strategy = subscriptionStrategy;
    }
    
}