namespace Presentation.Content.REST.Resources;

public record CreateTemplateResource(string Title, string Description, string Type,string ImgUrl,string Genre, string PortfolioTitle,string PortfolioDescription,int PortfolioQuantity, bool TemplateState);