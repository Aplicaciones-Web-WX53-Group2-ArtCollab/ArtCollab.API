using Domain.Content.Model.Commands;
using Presentation.Content.REST.Resources;

namespace Presentation.Content.REST.Transform;

public class DeleteTemplateCommandFromResourceAssembler
{
    public static DeleteTemplateCommand ToCommandFromResource (DeleteTemplateResource resource)
    {
        return new DeleteTemplateCommand(resource.Id);
    }
}