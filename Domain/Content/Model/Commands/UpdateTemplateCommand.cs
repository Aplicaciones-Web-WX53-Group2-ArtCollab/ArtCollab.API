namespace Domain.Content.Model.Commands;

public record UpdateTemplateCommand(string Title, string Description, string Type,string ImgUrl,string Genre);