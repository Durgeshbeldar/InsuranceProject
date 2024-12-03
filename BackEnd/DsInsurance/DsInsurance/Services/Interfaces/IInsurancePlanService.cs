using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IInsurancePlanService
    {
        List<InsurancePlanDto> GetAllPlans();
        InsurancePlanDto GetPlanById(Guid planId);
        Guid AddPlan(InsurancePlanDto planDto);
        void UpdatePlan(InsurancePlanDto planDto);
        void DeletePlan(Guid planId);
    }
}
