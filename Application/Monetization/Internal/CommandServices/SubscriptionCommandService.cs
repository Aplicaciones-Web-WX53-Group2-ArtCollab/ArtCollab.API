using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;
using Domain.Shared.Repositories;

namespace Application.Monetization.Internal.CommandServices;

public class SubscriptionCommandService(IUnitOfWork unitOfWork, ISubscriptionRepository subscriptionRepository) : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        await subscriptionRepository.AddAsync(subscription);
        await unitOfWork.CompleteAsync();
        return subscription;
    }

    public async Task<Subscription?> Handle(UpdateSubscriptionCommand command)
    {
        var subscription = await subscriptionRepository.GetByIdAsync(command.Id);
        if (subscription == null) return null;
        subscriptionRepository.Update(subscription);
        await unitOfWork.CompleteAsync();
        return subscription;
    }

    public async Task<Subscription?> Handle( DeleteSubscriptionCommand command)
    {
        var subscription = await subscriptionRepository.GetByIdAsync(command.Id);
        if (subscription == null) return null;
        subscriptionRepository.Delete(subscription);
        await unitOfWork.CompleteAsync();
        return subscription;
    }
}