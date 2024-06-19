using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;
using Domain.Content.Repositories;
using Domain.Content.Services;
using Domain.Shared.Repositories;

namespace Application.Content.Internal.CommandServices;

public class TemplateCommandService(IUnitOfWork unitOfWork, ITemplateRepository templateRepository) : ITemplateCommandService
{
    public async Task<Template?> Handle(CreateTemplateCommand command)
    {
        var template = new Template(command);
        await templateRepository.AddAsync(template);
        await unitOfWork.CompleteAsync();
        return template;
    }

    public async Task<Template?> Handle(int id, UpdateTemplateCommand command)
    {
        var template = await templateRepository.GetByIdAsync(id);
        if (template == null) return null;
        templateRepository.Update(template);
        await unitOfWork.CompleteAsync();
        return template;
    }

    public async Task<Template?> Handle(int id, DeleteTemplateCommand command)
    {
        var template = await templateRepository.GetByIdAsync(id);
        if (template == null) return null;
        templateRepository.Delete(template);
        await unitOfWork.CompleteAsync();
        return template;
    }
}