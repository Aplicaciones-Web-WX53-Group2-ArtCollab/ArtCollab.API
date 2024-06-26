using Domain.Content.Model.Aggregates;
using Presentation.Content.REST.Resources;

namespace Presentation.Content.REST.Transform;

public class TemplateResourceFromEntityAssembler
{
    public static TemplateResource ToResourceFromEntity(Template template)
    {
        return new TemplateResource(template.Id, template.Title, template.Description, template.Type, template.ImgUrl,
            template.Genre, template.Likes,template.Views,template.TemplateState.Flag);
    }
}