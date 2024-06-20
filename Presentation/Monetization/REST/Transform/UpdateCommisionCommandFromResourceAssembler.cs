using Domain.Monetization.Model.Commands;
using Presentation.Collaboration.REST.Resources;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class UpdateCommisionCommandFromResourceAssembler
{
    public static UpdateCommisionCommand ToCommandFromResource(int id,UpdateCommisionResource updateCommisionResource)
    {
        return new UpdateCommisionCommand(id, updateCommisionResource.Amount,updateCommisionResource.Content);
    }
}