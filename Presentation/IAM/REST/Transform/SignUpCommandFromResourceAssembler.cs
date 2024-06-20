using Domain.IAM.Model.Commands;
using Presentation.IAM.REST.Resources;

namespace Presentation.IAM.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}