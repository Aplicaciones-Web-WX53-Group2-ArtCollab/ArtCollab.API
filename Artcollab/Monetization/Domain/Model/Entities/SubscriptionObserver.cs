using Application.Monetization.Domain.Model.Aggregates;

namespace Application.Monetization.Domain.Model.Entities
{
    public class SubscriptionObserver : Observer<Subscription>
    {
     
        public override void Update(Subscription subscription)
        {
            subscription.IsActive = !subscription.IsActive;
        }
    }
}