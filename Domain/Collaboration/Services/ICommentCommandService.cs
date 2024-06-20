using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Commands;

namespace Domain.Collaboration.Services;

public interface ICommentCommandService
{
    Task<Comment?> Handle(CreateCommentCommand command);
    Task <Comment?> Handle(UpdateCommentCommand command);
    Task<Comment?> Handle(DeleteCommentCommand command);
}