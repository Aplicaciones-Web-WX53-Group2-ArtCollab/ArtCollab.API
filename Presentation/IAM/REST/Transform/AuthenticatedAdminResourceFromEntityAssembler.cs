using Domain.IAM.Model.Aggregates;
using Presentation.IAM.REST.Resources;

namespace Presentation.IAM.REST.Transform;

public class AuthenticatedAdminResourceFromEntityAssembler
{
    public static AuthenticatedAdminResource ToResourceFromEntity(Admin entity, string token)
    {
        return new AuthenticatedAdminResource(entity.Id, entity.Username, token);
    }
}