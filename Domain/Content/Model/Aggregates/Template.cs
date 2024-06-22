using Domain.Content.Model.Commands;
using Domain.Content.Model.Entities;

namespace Domain.Content.Model.Aggregates;

public partial class Template
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public string Type { get; set; }
    public string ImgUrl { get; set; }
    
    public string Genre { get; set; }
    
    public int PortfolioId { get; set; }
    
    public int TemplateStateId { get; set; }
    
    
    public TemplateHistory HistoryTemplate { get;  }
    
    public Portfolio Portfolio { get; set; }
    public TemplateState TemplateState { get; set; }
    
    
}

public partial class Template {
    
    public Template()
    {
        Title = string.Empty;
        Description = string.Empty;
        Type = string.Empty;
        ImgUrl = string.Empty;
        Genre = string.Empty;
        Portfolio = new Portfolio();
        TemplateState = new TemplateState();
    }

    public Template(CreateTemplateCommand command, Portfolio portfolio, TemplateState templateState)
    {
        Title = command.Title;
        Description = command.Description;
        Type = command.Type;
        ImgUrl = command.ImgUrl;
        Genre = command.Genre;
        Portfolio = portfolio;
        TemplateState = templateState;
        CreatedDate = DateTime.Now;
        HistoryTemplate = new TemplateHistory();
    }
}

