namespace Domain.Content.Model.Commands;

public record CreateTemplateCommand(string Title, string Description, string Type,string ImgUrl,string Genre, string PortfolioTitle,string PortfolioDescription,int PortfolioQuantity, bool TemplateState);