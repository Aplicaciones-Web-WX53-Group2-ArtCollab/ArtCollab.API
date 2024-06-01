using System.Runtime.InteropServices.JavaScript;
using Infraestructure.Models;

namespace Infraestructure;

public interface ICommentData
{
    Task<int> SaveCommentAsync(Comment data);
    
    Task<Boolean> UpdateCommentAsync(Comment data, int id);
    
    Task<Boolean> DeleteCommentAsync(int id);
    
    Task<List<Comment>> getAllCommentAsync();
    
    Task<Comment> getByIdCommentAsync(int Id);
    
    Task<Comment> getCommentByNameAsync(string name);
}