namespace Domain.User.Model.Commands;

public record CreateReaderCommand(string Name, string Username, string Email, string Password, string Type, string ImgUrl);