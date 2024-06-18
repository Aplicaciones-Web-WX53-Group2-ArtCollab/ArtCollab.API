using Infrastructure.Monetization.Model.Aggregates;

namespace Infrastructure.Monetization.Model.Entities;

public class WriterSubscriptionStrategy : ISubscriptionStrategy
{
    public void Subscribe(Subscription entity)
    {
        entity.IsActive = true;
    }
        
        
}