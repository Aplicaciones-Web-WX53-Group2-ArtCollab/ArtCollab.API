namespace Presentation.IAM.ACL;

public interface IIamContextFacade
{
    Task<int> CreateAdmin(string username, string password);
    Task<int> FetchAdminIdByUsername(string username);
    Task<string> FetchUsernameByAdminId(int userId);
}