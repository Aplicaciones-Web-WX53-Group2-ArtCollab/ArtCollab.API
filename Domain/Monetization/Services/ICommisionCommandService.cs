using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;

namespace Domain.Monetization.Services;

public interface ICommisionCommandService
{
    Task<Commision?> Handle(CreateCommisionCommand command);
    Task<Commision?> Handle(UpdateCommisionCommand command);
    Task<Commision?> Handle(DeleteCommisionCommand command);
}