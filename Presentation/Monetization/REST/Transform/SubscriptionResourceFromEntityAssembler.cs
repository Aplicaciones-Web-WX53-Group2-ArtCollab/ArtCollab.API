using Domain.Monetization.Model.Aggregates;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription subscription)
    {
        return new SubscriptionResource(subscription.Id, subscription.IsActive);
    }
}