using Domain.IAM.Model.Commands;
using Presentation.IAM.REST.Resources;

namespace Presentation.IAM.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}