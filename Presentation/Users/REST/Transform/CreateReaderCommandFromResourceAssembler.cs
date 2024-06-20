using Domain.User.Model.Commands;
using Presentation.Users.REST.Resources;

namespace Presentation.Users.REST.Transform;

public class CreateReaderCommandFromResourceAssembler
{
    public static CreateReaderCommand ToCommandFromResource(CreateReaderResource createReaderResource)
    {
        return new CreateReaderCommand(createReaderResource.Name, createReaderResource.Username,
            createReaderResource.Email, createReaderResource.Password, createReaderResource.Type,
            createReaderResource.ImgUrl);
    }
}