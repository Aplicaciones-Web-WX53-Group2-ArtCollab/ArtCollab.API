namespace Domain.User.Model.Commands;

public record UpdateReaderCommand(int Id, string Name, string Username, string Email, string Password, string Type, string ImgUrl);