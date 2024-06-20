using Domain.Monetization.Model.Commands;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class DeleteCommisionCommandFromEntityAssembler
{
    public static DeleteCommisionCommand ToCommandFromResource(DeleteCommisionResource deleteCommisionResource )
    {
        return new DeleteCommisionCommand(deleteCommisionResource.Id);
    }
}