namespace artcollab.API.Monetization.Interfaces.REST;

public class IlustrationSubscriptionStrategy : SubscriptionStrategy
{
    public override void Subscribe(Subscription subscription)
    {
        subscription.isActive = true;
    }
}