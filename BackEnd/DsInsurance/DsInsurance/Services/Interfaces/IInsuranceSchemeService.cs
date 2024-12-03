using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IInsuranceSchemeService
    {
        List<InsuranceSchemeDto> GetAllSchemes();
        InsuranceSchemeDto GetSchemeById(Guid schemeId);
        Guid AddScheme(InsuranceSchemeDto schemeDto);
        void UpdateScheme(InsuranceSchemeDto schemeDto);
        void DeleteScheme(Guid schemeId);
    }
}
