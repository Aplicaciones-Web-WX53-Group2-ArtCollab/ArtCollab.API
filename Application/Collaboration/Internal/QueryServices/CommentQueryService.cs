using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Queries;
using Domain.Collaboration.Repositories;
using Domain.Collaboration.Services;

namespace Application.Collaboration.Internal.QueryServices;

public class CommentQueryService(ICommentRepository commentRepository) : ICommentQueryService
{
    public async Task<IEnumerable<Comment?>> Handle(GetAllCommentsQuery query)
    {
        return await commentRepository.GetAllAsync();
    }

    public async Task<Comment?> Handle(GetCommentByIdQuery query)
    {
        return await commentRepository.GetByIdAsync(query.Id);
    }
}