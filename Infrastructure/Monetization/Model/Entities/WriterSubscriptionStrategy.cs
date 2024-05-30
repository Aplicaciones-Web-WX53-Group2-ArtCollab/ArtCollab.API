using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities;

public class WriterSubscriptionStrategy : ISubscriptionStrategy
{
    public void Subscribe(Subscription entity)
    {
        entity.IsActive = true;
    }
        
        
}