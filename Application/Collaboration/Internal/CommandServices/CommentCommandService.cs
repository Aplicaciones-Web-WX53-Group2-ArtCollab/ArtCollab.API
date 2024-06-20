using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Model.Commands;
using Domain.Collaboration.Repositories;
using Domain.Collaboration.Services;
using Domain.Shared.Repositories;

namespace Application.Collaboration.Internal.CommandServices;

public class CommentCommandService(IUnitOfWork unitOfWork, ICommentRepository commentRepository): ICommentCommandService
{
    public async Task<Comment?> Handle(CreateCommentCommand command)
    {
        var comment = new Comment(command);
        await commentRepository.AddAsync(comment);
        await unitOfWork.CompleteAsync();
        return comment;
    }

    public async Task<Comment?> Handle(UpdateCommentCommand command)
    {
        var comment = await commentRepository.GetByIdAsync(command.Id); 
        if(comment == null) return null;
        comment.Content = command.Comment;
        commentRepository.Update(comment);
        await unitOfWork.CompleteAsync();
        return comment;
    }

    public async Task<Comment?> Handle(DeleteCommentCommand command)
    {
        var comment = await commentRepository.GetByIdAsync(command.Id);
        if(comment == null) return null;
        commentRepository.Delete(comment);
        await unitOfWork.CompleteAsync();
        return comment;
    }
}