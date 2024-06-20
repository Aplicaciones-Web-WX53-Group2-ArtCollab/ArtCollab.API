using Domain.Collaboration.Model.Commands;
using Presentation.Collaboration.REST.Resources;

namespace Presentation.Collaboration.REST.Transform;

public record DeleteCommentCommandFromResourceAssembler()
{
    public static DeleteCommentCommand ToCommandFromResource(DeleteCommentResource resource)
    {
        return new DeleteCommentCommand(resource.Id);
    }
}