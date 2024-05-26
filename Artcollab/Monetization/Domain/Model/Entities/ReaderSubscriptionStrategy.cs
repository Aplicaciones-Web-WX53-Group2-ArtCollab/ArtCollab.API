namespace artcollab.API.Monetization.Interfaces.REST;

public class ReaderSubscriptionStrategy : SubscriptionStrategy
{
    public override void Subscribe(Subscription subscription)
    {
        subscription.isActive = true;
    }
}