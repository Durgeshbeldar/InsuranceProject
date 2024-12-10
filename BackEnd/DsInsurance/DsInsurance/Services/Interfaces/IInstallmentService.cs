using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IInstallmentService
    {
        List<InstallmentDto> GetAllInstallments();
        InstallmentDto GetInstallmentById(Guid id);
        Guid AddInstallment(InstallmentDto installmentDto);
        void UpdateInstallment(InstallmentDto installmentDto);
    }
}
