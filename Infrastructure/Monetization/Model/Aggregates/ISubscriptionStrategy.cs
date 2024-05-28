

using Domain.Monetization.Model.Aggregates;
namespace Infraestructure.Monetization.Model.Aggregates
{
    public interface ISubscriptionStrategy
    {
        public void Subscribe(Subscription entity);
    }
}