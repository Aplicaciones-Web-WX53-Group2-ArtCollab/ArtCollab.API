using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities;

public class SubscriptionManager
{
    
    private ISubscriptionStrategy _subscriptionStrategy;
    
    public SubscriptionManager(ISubscriptionStrategy subscriptionStrategy)
    {
        _subscriptionStrategy = subscriptionStrategy;
    }
    
    public void SetSubscriptionStrategy(ISubscriptionStrategy subscriptionStrategy)
    {
        _subscriptionStrategy = subscriptionStrategy;
    }
    
}