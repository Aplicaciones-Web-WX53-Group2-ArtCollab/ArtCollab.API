using Infraestructure;
using Infraestructure.Models;

namespace Domain;

public class CommentDomain : ICommentDomain
{
    private ICommentData _commentData;
    
    public CommentDomain(ICommentData commentData)
    {
        _commentData = commentData;
    }

    public async Task<int> SaveCommentAsync(Comment data)
    {
        data.Date = DateTime.Now;
        return await _commentData.SaveCommentAsync(data);
    }

    public async Task<Boolean> UpdateCommentAsync(Comment data, int id)
    {
        var existingComment = _commentData.getByIdCommentAsync(id);

        return await _commentData.UpdateCommentAsync(data, id);
    }

    public async Task<Boolean> DeleteCommentAsync(int id)
    {
        return await _commentData.DeleteCommentAsync(id);
    }
}