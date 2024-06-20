using Domain.Monetization.Model.Commands;
using Presentation.Monetization.REST.Resources;

namespace Presentation.Monetization.REST.Transform;

public class CreateCommisionCommandFromResourceAssembler
{
    public static CreateCommisionCommand ToCommandFromResource(CreateCommisionResource commisionResource)
    {
        return new CreateCommisionCommand(commisionResource.Amount, commisionResource.Content);
    }
}