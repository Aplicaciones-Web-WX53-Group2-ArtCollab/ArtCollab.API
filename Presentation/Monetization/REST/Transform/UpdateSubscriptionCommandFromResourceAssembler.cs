using Domain.Monetization.Model.Commands;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class UpdateSubscriptionCommandFromResourceAssembler
{
    public static UpdateSubscriptionCommand ToCommandFromResource(int id,UpdateSubscriptionResource updateSubscriptionResource)
    {
        return new UpdateSubscriptionCommand(id, updateSubscriptionResource.IsActive);
    }
}