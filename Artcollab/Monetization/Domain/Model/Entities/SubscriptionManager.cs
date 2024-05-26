namespace artcollab.API.Monetization.Interfaces.REST;

public class SubscriptionManager
{
    
    private SubscriptionStrategy _subscriptionStrategy;
    
    public SubscriptionManager(SubscriptionStrategy subscriptionStrategy)
    {
        _subscriptionStrategy = subscriptionStrategy;
    }
    
    public void SetSubscriptionStrategy(SubscriptionStrategy subscriptionStrategy)
    {
        _subscriptionStrategy = subscriptionStrategy;
    }
    
}