using Domain.Content.Model.Commands;
using Presentation.Content.REST.Resources;

namespace Presentation.Content.REST.Transform;

public class UpdateTemplateCommandFromResourceAssembler
{
    public static UpdateTemplateCommand ToCommandFromResource(int id,UpdateTemplateResource resource)
    {
        return new UpdateTemplateCommand(id,resource.Title, resource.Description, resource.Type,
            resource.ImgUrl,
            resource.Genre,resource.PortfolioTitle, resource.PortfolioDescription, 
            resource.PortfolioQuantity);
    }
}