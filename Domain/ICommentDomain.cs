using Infraestructure.Models;

namespace Domain;

public interface ICommentDomain
{
    Task<int> SaveCommentAsync(Comment data);
    
    Task<Boolean> UpdateCommentAsync(Comment data, int id);
    
    Task<Boolean> DeleteCommentAsync(int id);
}