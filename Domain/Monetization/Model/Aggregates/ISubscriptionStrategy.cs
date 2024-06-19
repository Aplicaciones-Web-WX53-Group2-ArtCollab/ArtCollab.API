

using Domain.Monetization.Model.Aggregates;

namespace Infrastructure.Monetization.Model.Aggregates
{
    public interface ISubscriptionStrategy
    {
        public void Subscribe(Subscription entity);
    }
}