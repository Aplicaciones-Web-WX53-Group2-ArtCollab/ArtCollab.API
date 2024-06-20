using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Queries;
using Domain.IAM.Services;

namespace Presentation.IAM.ACL.Services;

public class IamContextFacade(IAdminCommandService adminCommandService, IAdminQueryService adminQueryService) : IIamContextFacade
{
    public async Task<int> CreateAdmin(string username, string password)
    {
        var signUpCommand = new SignUpCommand(username, password);
        await adminCommandService.Handle(signUpCommand);
        var getAdminByUsernameQuery = new GetAdminByUsernameQuery(username);
        var admin = await adminQueryService.Handle(getAdminByUsernameQuery);
        return admin?.Id ?? 0;
    }

    public async Task<int> FetchAdminIdByUsername(string username)
    {
        var getAdminByUsernameQuery = new GetAdminByUsernameQuery(username);
        var admin = await adminQueryService.Handle(getAdminByUsernameQuery);
        return admin?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByAdminId(int userId)
    {
        var getAdminByIdQuery = new GetAdminByIdQuery(userId);
        var admin = await adminQueryService.Handle(getAdminByIdQuery);
        return admin?.Username ?? string.Empty;
    }
}