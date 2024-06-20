using Domain.IAM.Model.Aggregates;
using Domain.Shared.Repositories;

namespace Domain.IAM.Repositories;

public interface IAdminRepository : IBaseRepository<Admin>
{
    Task<Admin?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}