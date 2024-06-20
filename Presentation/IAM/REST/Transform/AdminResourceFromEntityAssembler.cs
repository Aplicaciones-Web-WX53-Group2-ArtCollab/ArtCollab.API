using Domain.IAM.Model.Aggregates;
using Presentation.IAM.REST.Resources;

namespace Presentation.IAM.REST.Transform;

public class AdminResourceFromEntityAssembler
{
    public static AdminResource ToResourceFromEntity(Admin entity)
    {
        return new AdminResource(entity.Id, entity.Username);
    }
}