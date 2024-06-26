namespace Domain.Content.Model.Commands;

public record CreateTemplateCommand(string Title, string Description, string Type,string ImgUrl,string Genre, int Likes, int Views, string PortfolioTitle,string PortfolioDescription,int PortfolioQuantity, bool TemplateState);