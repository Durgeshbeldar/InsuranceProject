using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IRoleService
    {
        List<RoleDto> GetAllRoles();
        RoleDto GetRoleById(Guid roleId);
        Guid AddRole(RoleDto roleDto);
        void UpdateRole(RoleDto roleDto);
        void DeleteRole(Guid roleId);
    }
}
