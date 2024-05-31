using System.Data;
using Domain.Interfaces;
using Infraestructure.Content.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Models;

namespace Domain;

public class RepositoryGeneric<TEntity>(IRepository<TEntity> repository, ITemplateData<Template> templateData) : IRepositoryGeneric<TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository = repository;
    private readonly ITemplateData<Template> _templateData = templateData;
    
    public async Task Add(TEntity entity)
    {
        if (entity is Template template)
        {
            if (template.Type == "Illustration" && !string.IsNullOrWhiteSpace(template.Genre))
            {
                throw new Exception("When the Type is 'Illustration', the Genre needs to be an empty string.");
            }

            template.Genre = template.Genre ?? string.Empty;
            
            var existingTemplateByDescription = await _templateData.GetByDescriptionAsync(template.Description);
            if (existingTemplateByDescription != null)
            {
                throw new Exception("A template with the same description already exists");
            }
            
            var existingTemplateByCoverImage = await _templateData.GetByCoverImageAsync(template.ImgUrl);
            if (existingTemplateByCoverImage != null)
            {
                throw new Exception("A template with the same cover image already exists");
            }
        }
        
        await _repository.Add(entity);
    }

    public async Task Delete(int id)
    {
        var existingTutorial = await _repository.GetByIdAsync(id);
        if (existingTutorial == null)
            throw new ConstraintException("Template not found");
        
        await _repository.Delete(id);
    }
}