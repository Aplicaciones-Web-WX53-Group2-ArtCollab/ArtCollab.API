using Domain.Monetization.Model.Commands;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class DeleteSubscriptionCommandFromResourceAssembler
{
    public static DeleteSubscriptionCommand ToCommandFromResource(DeleteSubscriptionResource deleteSubscriptionResource)
    {
        return new DeleteSubscriptionCommand(deleteSubscriptionResource.Id);
    }
}