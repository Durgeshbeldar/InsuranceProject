using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IAdminService
    {
        List<AdminDto> GetAllAdmins();
        AdminDto GetAdminById(Guid adminId);
        Guid AddAdmin(AdminDto adminDto);
        void UpdateAdmin(AdminDto adminDto);
        void DeleteAdmin(Guid adminId);

    }
}
