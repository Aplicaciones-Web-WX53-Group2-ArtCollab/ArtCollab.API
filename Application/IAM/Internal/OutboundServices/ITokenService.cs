using Domain.IAM.Model.Aggregates;

namespace Application.IAM.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(Admin admin);
    Task<int?> ValidateToken(string token);
}