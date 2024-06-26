namespace Presentation.Content.REST.Resources;

public record UpdateTemplateResource(string Title, string Description, string Type,string ImgUrl,string Genre, string PortfolioTitle, int Likes, int Views,string PortfolioDescription,int PortfolioQuantity, bool TemplateState);