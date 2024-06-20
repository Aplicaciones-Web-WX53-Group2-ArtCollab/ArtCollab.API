using Domain.Collaboration.Model.Commands;
using Presentation.Collaboration.REST.Resources;

namespace Presentation.Collaboration.REST.Transform;

public record CreateCommentCommandFromResourceAssembler()
{
    public static CreateCommentCommand ToCommandFromResource(CreateCommentResource resource)
    {
        return new CreateCommentCommand(resource.Content);
    }
}