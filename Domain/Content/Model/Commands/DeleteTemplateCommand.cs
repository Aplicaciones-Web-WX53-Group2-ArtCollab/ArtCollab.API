namespace Domain.Content.Model.Commands;

public record DeleteTemplateCommand(string Title, string Description, string Type,string ImgUrl,string Genre);