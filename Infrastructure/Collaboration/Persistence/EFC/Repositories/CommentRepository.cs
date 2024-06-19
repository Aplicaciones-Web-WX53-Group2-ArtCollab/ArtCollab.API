using Domain.Collaboration.Model.Aggregates;
using Domain.Collaboration.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Collaboration.Persistence.EFC.Repositories;

public class CommentRepository(AppDbContext context) : BaseRepository<Comment>(context), ICommentRepository
{
  
}