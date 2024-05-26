using artcollab.API.Monetization.Interfaces.REST;

namespace Application.Monetization.Domain.Model.Aggregates;

public interface ISubscriptionStrategy
{
    public void Subscribe(Subscription entity);
}

