using Application.Monetization.Domain.Model.Aggregates;
using artcollab.API.Monetization.Interfaces.REST;

namespace Application.Monetization.Domain.Model.Entities
{
    public class WriterSubscriptionStrategy : ISubscriptionStrategy
    {
        public void Subscribe(Subscription entity)
        {
            entity.IsActive = true;
        }
    }
}