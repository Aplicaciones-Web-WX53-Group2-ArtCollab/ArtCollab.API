using Domain.Collaboration.Model.Commands;
using Presentation.Collaboration.REST.Resources;

namespace Presentation.Collaboration.REST.Transform;

public record UpdateCommentCommandFromResourceAssembler()
{
    public static UpdateCommentCommand ToCommandFromResource(int id,UpdateCommentResource resource)
    {
        return new UpdateCommentCommand(id,resource.Content);
    }
}