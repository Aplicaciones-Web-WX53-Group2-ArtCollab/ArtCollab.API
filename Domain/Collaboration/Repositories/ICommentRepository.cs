using Domain.Collaboration.Model.Aggregates;
using Domain.Shared.Repositories;

namespace Domain.Collaboration.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
}