using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Queries;
using Domain.IAM.Repositories;
using Domain.IAM.Services;

namespace Application.IAM.Internal.QueryServices;

public class AdminQueryService(IAdminRepository adminRepository) : IAdminQueryService
{
    public async Task<Admin?> Handle(GetAdminByUsernameQuery query)
    {
        return await adminRepository.FindByUsernameAsync(query.Username);
    }

    public async Task<Admin?> Handle(GetAdminByIdQuery query)
    {
        return await adminRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Admin?>> Handle(GetAllAdminsQuery query)
    {
        return await adminRepository.GetAllAsync();
    }
}