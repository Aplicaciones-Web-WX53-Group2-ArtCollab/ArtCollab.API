namespace Presentation.Users.REST.Resources;

public record UpdateReaderResource(string Name, string Username, string Email, string Password, string Type, string ImgUrl);