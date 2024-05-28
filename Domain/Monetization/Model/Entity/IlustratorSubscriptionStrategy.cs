using Domain.Monetization.Model.Aggregates;

namespace Domain.Monetization.Model.Entity;

public interface ILustratorSubscriptionStrategy
{
    public void Subscribe(Subscription subscription)
    {
        subscription.IsActive = true;
    }
}