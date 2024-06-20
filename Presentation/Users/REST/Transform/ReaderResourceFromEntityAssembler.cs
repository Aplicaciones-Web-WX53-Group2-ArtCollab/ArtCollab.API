using Domain.User.Model.Aggregates;
using Presentation.Users.REST.Resources;

namespace Presentation.Users.REST.Transform;

public class ReaderResourceFromEntityAssembler
{
    public static ReaderResource ToResourceFromEntity(Reader reader)
    {
        return new ReaderResource( reader.Id,reader.Username, reader.Type, reader.ImgUrl);
    }
}