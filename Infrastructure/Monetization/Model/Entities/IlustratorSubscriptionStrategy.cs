using Domain.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities
{
    public interface ILustratorSubscriptionStrategy
    {
        public void Subscribe(Subscription subscription)
        {
            subscription.IsActive = true;
        }
    }
}