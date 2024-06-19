using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Commands;

namespace Domain.Collaboration.Services;

public interface ICommentCommandService
{
    Task<Comment?> Handle(CreateCommentCommand command);
    Task <Comment?> Handle(int id,UpdateCommentCommand command);
    Task<Comment?> Handle(int id,DeleteCommentCommand command);
}