using Domain.Monetization.Model.Aggregates;

namespace Domain.Monetization.Model.Entity;

public class SubscriptionManager(ISubscriptionStrategy strategy)
{
    public void SetSubscriptionStrategy(ISubscriptionStrategy subscriptionStrategy)
    {
        strategy = subscriptionStrategy;
    }
    
}