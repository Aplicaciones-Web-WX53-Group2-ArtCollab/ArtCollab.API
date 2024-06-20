using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource createSubscriptionResource)
    {
        return new CreateSubscriptionCommand();
    }
}