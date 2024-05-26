namespace artcollab.API.Monetization.Interfaces.REST;

public class WriterSubscriptionStrategy : SubscriptionStrategy
{
    public override void Subscribe(Subscription subscription)
    {
        subscription.isActive = true;
    }
}