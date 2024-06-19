using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Queries;

namespace Domain.Monetization.Services;

public interface ICommisionQueryService
{
    Task<IEnumerable<Commision?>> Handle(GetAllCommisionsQuery query);
    Task<Commision?> Handle(GetCommisionByIdQuery query);
}