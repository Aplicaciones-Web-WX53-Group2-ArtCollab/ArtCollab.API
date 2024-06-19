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
        await commisionRepository.AddAsync(commision);
        await unitOfWork.CompleteAsync();
        return commision;
    }

    public async Task<Commision?> Handle(int id, UpdateCommisionCommand command)
    {
        var commision = await commisionRepository.GetByIdAsync(id);
        if (commision == null) return null;
        commisionRepository.Update(commision);
        await unitOfWork.CompleteAsync();
        return commision;
    }

    public async Task<Commision?> Handle(int id, DeleteCommisionCommand command)
    {
        var commision = await commisionRepository.GetByIdAsync(id);
        if (commision == null) return null;
        commisionRepository.Delete(commision);
        await unitOfWork.CompleteAsync();
        return commision;
    }
}