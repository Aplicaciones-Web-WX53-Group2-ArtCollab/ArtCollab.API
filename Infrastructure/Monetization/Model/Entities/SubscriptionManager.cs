using Infraestructure.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities;

public class SubscriptionManager(ISubscriptionStrategy strategy)
{
    public void SetSubscriptionStrategy(ISubscriptionStrategy subscriptionStrategy)
    {
        strategy = subscriptionStrategy;
    }
    
}