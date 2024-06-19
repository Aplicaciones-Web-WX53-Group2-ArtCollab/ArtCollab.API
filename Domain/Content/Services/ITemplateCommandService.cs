using Domain.Content.Models.Commands;

namespace Domain.Content.Services;

public interface ITemplateCommandService
{
    Task<int> Handle(CreateTemplateCommand command);
    Task<bool> Handle(UpdateTemplateCommand command);
    Task<bool> Handle(DeleteTemplateCommand command);
}