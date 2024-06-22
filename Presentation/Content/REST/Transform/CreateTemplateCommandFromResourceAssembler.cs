using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Commands;
using Presentation.Content.REST.Resources;

namespace Presentation.Content.REST.Transform;

public class CreateTemplateCommandFromResourceAssembler
{
    public static CreateTemplateCommand ToResourceFromEntity(CreateTemplateResource createTemplateResource)
    {
        return new CreateTemplateCommand(createTemplateResource.Title, createTemplateResource.Description,
            createTemplateResource.Type, createTemplateResource.ImgUrl, createTemplateResource.Genre,
            createTemplateResource.PortfolioTitle, createTemplateResource.PortfolioDescription, 
            createTemplateResource.PortfolioQuantity);
    }
}