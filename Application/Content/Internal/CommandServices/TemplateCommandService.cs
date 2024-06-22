using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;
using Domain.Content.Model.Entities;
using Domain.Content.Repositories;
using Domain.Content.Services;
using Domain.Shared.Repositories;
using Shared;

namespace Application.Content.Internal.CommandServices;

public class TemplateCommandService(IUnitOfWork unitOfWork, ITemplateRepository templateRepository) : ITemplateCommandService
{
    public async Task<Template?> Handle(CreateTemplateCommand command)
    {
        var templateState = new TemplateState(command.TemplateState);
        var portfolio = new Portfolio(command.PortfolioTitle,command.PortfolioDescription, command.PortfolioQuantity);
        var template = new Template(command,portfolio, templateState);
        var templateWithTitleExists = templateRepository.TemplateByTitleExists(command.Title);
        if (templateWithTitleExists)
        {
            throw new TemplateWithTheSameTitleAlreadyExistException();
        }
        await templateRepository.AddAsync(template);
        await unitOfWork.CompleteAsync();
        return template;
    }

    public async Task<Template?> Handle(UpdateTemplateCommand command)
    {
        var template = await templateRepository.GetByIdAsync(command.Id);
        if (template == null) return null;
        template.Title = command.Title;
        template.Description = command.Description;
        template.Type = command.Type;
        template.ImgUrl = command.ImgUrl;
        template.Genre = command.Genre;
        template.Portfolio.Title = command.PortfolioTitle;
        template.Portfolio.Description = command.PortfolioDescription;
        template.Portfolio.Quantity = command.PortfolioQuantity;
        template.TemplateState.Flag = command.TemplateState;
        templateRepository.Update(template);
        await unitOfWork.CompleteAsync();
        return template;
    }

    public async Task<Template?> Handle(DeleteTemplateCommand command)
    {
        var template = await templateRepository.GetByIdAsync(command.Id);
        if (template == null) return null;
        templateRepository.Delete(template);
        await unitOfWork.CompleteAsync();
        return template;
    }
}