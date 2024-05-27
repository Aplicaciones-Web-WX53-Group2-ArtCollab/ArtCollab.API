using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Models;

namespace Infraestructure;

public class CommentMySqlData : ICommentData
{
    private ArtCollabDBContext _artCollabDbContext;
    
    public CommentMySqlData(ArtCollabDBContext artCollabDbContext)
    {
        _artCollabDbContext = artCollabDbContext;
    }
    
    public async Task<int> SaveCommentAsync(Comment data)
    {
        data.IsActive = true;
        using (var transaction = await _artCollabDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _artCollabDbContext.Comments.Add(data);
                await _artCollabDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return data.Id;
    }

    public async Task<bool> UpdateCommentAsync(Comment data, int id)
    {
        using (var transaction = await _artCollabDbContext.Database.BeginTransactionAsync())
        {
            var commentToUpdate = _artCollabDbContext.Comments.Where(t => t.Id == id).FirstOrDefault();
            commentToUpdate.Content = data.Content;
            
            _artCollabDbContext.Comments.Update(commentToUpdate);
            await _artCollabDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return true;
    }

    public async Task<Boolean> DeleteCommentAsync(int id)
    {
        using (var transaction = await _artCollabDbContext.Database.BeginTransactionAsync())
        {
            var commentToDelete = _artCollabDbContext.Comments.Where(t => t.Id == id).FirstOrDefault();
            commentToDelete.IsActive = false;
            
            await _artCollabDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return true;
    }

    public async Task<List<Comment>> getAllCommentAsync()
    {
        return await _artCollabDbContext.Comments.Where(t => t.IsActive)
            .ToListAsync();
    }

    public async Task<Comment> getByIdCommentAsync(int Id)
    {
        return await _artCollabDbContext.Comments.Where(t => t.Id == Id)
            .FirstOrDefaultAsync();
    }
}