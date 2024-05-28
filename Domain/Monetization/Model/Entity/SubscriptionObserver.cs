using Domain.Monetization.Model.Aggregates;

namespace Domain.Monetization.Model.Entity;

public class SubscriptionObserver : Observer<Subscription>
{
     
    public override void Update(Subscription subscription)
    {
        subscription.IsActive = !subscription.IsActive;
    }
}