using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;

namespace Domain.Monetization.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
    Task<Subscription?> Handle(UpdateSubscriptionCommand command);
    Task<Subscription?> Handle(DeleteSubscriptionCommand command);
}