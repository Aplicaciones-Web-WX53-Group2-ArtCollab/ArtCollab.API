using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Domain.Monetization.Model.Entity;

public class WriterSubscriptionStrategy : ISubscriptionStrategy
{
    public void Subscribe(Subscription entity)
    {
        entity.IsActive = true;
    }
        
        
}