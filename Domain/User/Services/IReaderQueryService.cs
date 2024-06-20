using Domain.User.Model.Aggregates;
using Domain.User.Model.Queries;

namespace Domain.User.Services;

public interface IReaderQueryService
{
    Task<IEnumerable<Reader?>> Handle(GetAllReadersQuery query);
    Task<Reader?> Handle(GetReaderByIdQuery query);
    Task<IEnumerable<Reader?>> Handle(GetAllReadersByTypeQuery query);
}