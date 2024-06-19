using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;

namespace Domain.Content.Services;

public interface ITemplateCommandService
{
    Task<Template?> Handle(CreateTemplateCommand command);
    Task<Template?> Handle(int id,UpdateTemplateCommand command);
    Task<Template?> Handle(int id,DeleteTemplateCommand command);
}