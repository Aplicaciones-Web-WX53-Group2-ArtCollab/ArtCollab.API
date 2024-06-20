using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Commands;

namespace Domain.IAM.Services;

public interface IAdminCommandService
{
    Task<(Admin admin, string token)> Handle(SignInCommand command);
    Task Handle(SignUpCommand command);
}