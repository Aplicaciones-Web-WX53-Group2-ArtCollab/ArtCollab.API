using Domain.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities;

public class SubscriptionObserver : Observer<Subscription>
{
     
    public override void Update(Subscription subscription)
    {
        subscription.IsActive = !subscription.IsActive;
    }
}