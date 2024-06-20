using Domain.Collaboration.Model.Aggregates;
using Presentation.Collaboration.REST.Resources;

namespace Presentation.Collaboration.REST.Transform;

public class CommentResourceFromEntityAssembler
{
    public static CommentResource ToResourceFromEntity(Comment? comment)
    {
        return new CommentResource(comment.Id, comment.Content);
    }
}