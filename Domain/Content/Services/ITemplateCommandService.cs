using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;

namespace Domain.Content.Services;

public interface ITemplateCommandService
{
    Task<Template?> Handle(CreateTemplateCommand command);
    Task<Template?> Handle(UpdateTemplateCommand command);
    Task<Template?> Handle(DeleteTemplateCommand command);
}