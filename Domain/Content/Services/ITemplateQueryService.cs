using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Queries;

namespace Domain.Content.Services;

public interface ITemplateQueryService
{
    Task<IEnumerable<Template?>>Handle (GetAllTemplatesQuery query);
    Task<Template?> Handle(GetTemplateByIdQuery query);
    Task<IEnumerable<Template?>> Handle(GetTemplatesByGenreQuery query);
    Task<Template?> Handle (GetTemplateByCoverImageQuery query);
    Task<Template?> Handle(GetTemplateByDescriptionQuery query);
    
}