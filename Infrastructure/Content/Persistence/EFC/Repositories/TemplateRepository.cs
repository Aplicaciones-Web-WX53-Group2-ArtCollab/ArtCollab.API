using Domain.Content.Model.Aggregates;
using Domain.Content.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Persistence.EFC.Repositories;

public class TemplateRepository(AppDbContext context ): BaseRepository<Template>(context), ITemplateRepository
{
    public bool TemplateByTitleExists(string title)
    {
        return context.Set<Template>().Any(t => t.Title == title);
    }

    public async Task<IEnumerable<Template?>> GetTemplatesByGenre(string genre)
    {
        return await context.Set<Template>().Where(t => t.Genre == genre).ToListAsync();
    }

    public async Task<Template?> GetTemplateByCoverImage(string imgUrl)
    {
        return await context.Set<Template>().FirstOrDefaultAsync(t => t.ImgUrl == imgUrl);
    }

    public async Task<Template?> GetTemplateByDescription(string description)
    {
        return await context.Set<Template>().FirstOrDefaultAsync(t => t.Description == description);
    }
}