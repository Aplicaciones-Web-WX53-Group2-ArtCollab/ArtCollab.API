using Domain.User.Model.Commands;
using Presentation.Users.REST.Resources;

namespace Presentation.Users.REST.Transform;

public class UpdateReaderCommandFromResourceAssembler
{
    public static UpdateReaderCommand ToCommandFromResource(int id,UpdateReaderResource updateReaderResource)
    {
        return new UpdateReaderCommand(id,
            updateReaderResource.Name,
            updateReaderResource.Username, updateReaderResource.Email,
            updateReaderResource.Password, updateReaderResource.Type, updateReaderResource.ImgUrl);
    }
}