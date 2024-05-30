using Domain.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Aggregates;

namespace Infraestructure.Monetization.Model.Entities;

public class SubscriptionObserver : Observer
{
    public override TaskStatus Update()
    {
        return TaskStatus.Created;
    }
}