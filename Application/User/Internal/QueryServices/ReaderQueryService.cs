using Domain.User.Model.Aggregates;
using Domain.User.Model.Queries;
using Domain.User.Repositories;
using Domain.User.Services;

namespace Application.User.Internal.QueryServices;

public class ReaderQueryService(IReaderRepository readerRepository) : IReaderQueryService
{
    public async Task<IEnumerable<Reader?>> Handle(GetAllReadersQuery query)
    {
        return await readerRepository.GetAllAsync();
    }

    public async Task<Reader?> Handle(GetReaderByIdQuery query)
    {
        return await readerRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Reader?>> Handle(GetAllReadersByTypeQuery query)
    {
        return await readerRepository.GetAllReadersByType(query.Type);
    }
}