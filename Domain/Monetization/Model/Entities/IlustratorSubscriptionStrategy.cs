using Domain.Monetization.Model.Aggregates;
using Infrastructure.Monetization.Model.Aggregates;

namespace Infrastructure.Monetization.Model.Entities
{
    public interface ILustratorSubscriptionStrategy
    {
        public void Subscribe(Subscription subscription)
        {
            subscription.IsActive = true;
        }
    }
}