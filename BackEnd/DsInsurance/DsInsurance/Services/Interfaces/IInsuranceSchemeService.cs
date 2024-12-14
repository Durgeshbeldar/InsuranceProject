using DsInsurance.DTOs;
using DsInsurance.Models;

namespace DsInsurance.Services.Interfaces
{
    public interface IInsuranceSchemeService
    {
        List<InsuranceSchemeDto> GetAllSchemes();
        InsuranceSchemeDto GetSchemeById(Guid schemeId);
        Guid AddScheme(InsuranceSchemeDto schemeDto);
        void UpdateScheme(InsuranceSchemeDto schemeDto);
        void DeleteScheme(Guid schemeId);
        public List<InsuranceSchemeDto> getSchemesByPlanId(Guid planId);
    }
}
