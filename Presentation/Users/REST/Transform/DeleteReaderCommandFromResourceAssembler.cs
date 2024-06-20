using Domain.User.Model.Commands;
using Presentation.Users.REST.Resources;

namespace Presentation.Users.REST.Transform;

public class DeleteReaderCommandFromResourceAssembler
{
    public static DeleteReaderCommand ToCommandFromResource(DeleteReaderResource resource)
    {
        return new DeleteReaderCommand(resource.Id);
    }
}