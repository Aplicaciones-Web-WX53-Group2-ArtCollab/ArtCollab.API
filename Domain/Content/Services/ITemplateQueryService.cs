using Domain.Content.Models.Queries;
using Domain.Content.Models.Response;

namespace Domain.Content.Services;

public interface ITemplateQueryService
{
    Task<List<TemplateResponse>?> Handle(GetAllTemplatesQuery query);
    Task<TemplateResponse?> Handle(GetTemplateByIdQuery query);
    Task<List<TemplateResponse>?> Handle(GetTemplateByGenreQuery query);
}