using Domain.Monetization.Model.Aggregates;
using Domain.Monetization.Model.Commands;
using Domain.Monetization.Repositories;
using Domain.Monetization.Services;
using Domain.Shared.Repositories;

namespace Application.Monetization.Internal.CommandServices;

public class CommisionCommandService(IUnitOfWork unitOfWork, ICommisionRepository commisionRepository) : ICommisionCommandService
{
    public async Task<Commision?> Handle(CreateCommisionCommand command)
    {
        var commision = new Commision(command);
        if (commision.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than 0");
        }
        await commisionRepository.AddAsync(commision);
        await unitOfWork.CompleteAsync();
        return commision;
    }

    public async Task<Commision?> Handle(UpdateCommisionCommand command)
    {
        var commision = await commisionRepository.GetByIdAsync(command.Id);
        if (commision == null) return null;
        commision.Amount = command.Amount;
        commision.Content = command.Content;
        commisionRepository.Update(commision);
        await unitOfWork.CompleteAsync();
        return commision;
    }

    public async Task<Commision?> Handle(DeleteCommisionCommand command)
    {
        var commision = await commisionRepository.GetByIdAsync(command.Id);
        if (commision == null) return null;
        commisionRepository.Delete(commision);
        await unitOfWork.CompleteAsync();
        return commision;
    }
}