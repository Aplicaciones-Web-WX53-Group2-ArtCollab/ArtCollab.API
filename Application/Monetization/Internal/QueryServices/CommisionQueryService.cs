using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Queries;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;

namespace Application.Monetization.Internal.QueryServices;

public class CommisionQueryService(ICommisionRepository commisionRepository) : ICommisionQueryService
{
    public async Task<IEnumerable<Commision?>> Handle(GetAllCommisionsQuery query)
    {
        return await commisionRepository.GetAllAsync();
    }

    public async Task<Commision?> Handle(GetCommisionByIdQuery query)
    {
        return await commisionRepository.GetByIdAsync(query.Id);
    }
}