namespace Presentation.Users.REST.Resources;

public record DeleteReaderResource(int Id,string Name, string Username, string Email, string Password, string Type, string ImgUrl);