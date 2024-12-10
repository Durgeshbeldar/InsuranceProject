using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IPolicyCoverageService
    {
        List<PolicyCoverageDto> GetAllPolicyCoverages();
        PolicyCoverageDto GetPolicyCoverageById(Guid coverageId);
        Guid AddPolicyCoverage(PolicyCoverageDto coverageDto);
        void UpdatePolicyCoverage(PolicyCoverageDto coverageDto);
    }
}
