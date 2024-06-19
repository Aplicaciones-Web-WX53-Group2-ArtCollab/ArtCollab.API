using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Queries;

namespace Domain.Collaboration.Services;

public interface ICommentQueryService
{
    Task<IEnumerable<Comment?>> Handle(GetAllCommentsQuery query);
    Task<Comment?> Handle(GetCommentByIdQuery query);
}