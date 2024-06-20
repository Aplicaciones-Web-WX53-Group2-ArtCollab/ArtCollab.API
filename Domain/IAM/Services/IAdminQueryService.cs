using Domain.IAM.Model.Aggregates;
using Domain.IAM.Model.Queries;

namespace Domain.IAM.Services;

public interface IAdminQueryService
{
    Task<Admin?> Handle(GetAdminByUsernameQuery query);
    Task<Admin?> Handle(GetAdminByIdQuery query);
    Task<IEnumerable<Admin?>> Handle(GetAllAdminsQuery query);
}