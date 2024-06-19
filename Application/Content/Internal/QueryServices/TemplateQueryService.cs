using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Queries;
using Domain.Content.Repositories;
using Domain.Content.Services;

namespace Application.Content.Internal.QueryServices;

public class TemplateQueryService(ITemplateRepository templateRepository) : ITemplateQueryService
{
    public async Task<IEnumerable<Template?>> Handle(GetAllTemplatesQuery query)
    {
        return await templateRepository.GetAllAsync();
    }

    public async Task<Template?> Handle(GetTemplateByIdQuery query)
    {
        return await templateRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Template?>> Handle(GetTemplatesByGenreQuery query)
    {
        return await templateRepository.GetTemplatesByGenre(query.Genre);
    }

    public async Task<Template?> Handle(GetTemplateByCoverImageQuery query)
    {
        return await templateRepository.GetTemplateByCoverImage(query.ImgUrl);
    }

    public async Task<Template?> Handle(GetTemplateByDescriptionQuery query)
    {
        return await templateRepository.GetTemplateByDescription(query.Description);
    }
}