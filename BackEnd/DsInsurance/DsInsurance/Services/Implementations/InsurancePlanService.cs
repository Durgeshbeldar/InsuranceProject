using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class InsurancePlanService : IInsurancePlanService
    {
        private readonly IRepository<InsurancePlan> _planRepository;
        private readonly IMapper _mapper;

        public InsurancePlanService(IRepository<InsurancePlan> planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public List<InsurancePlanDto> GetAllPlans()
        {
            var plans = _planRepository.GetAll().ToList();
            if (!plans.Any())
                throw new NotFoundException("InsurancePlans");

            return _mapper.Map<List<InsurancePlanDto>>(plans);
        }

        public InsurancePlanDto GetPlanById(Guid planId)
        {
            var plan = _planRepository.GetById(planId);
            if (plan == null)
                throw new NotFoundException("InsurancePlan");

            return _mapper.Map<InsurancePlanDto>(plan);
        }

        public Guid AddPlan(InsurancePlanDto planDto)
        {
            var plan = _mapper.Map<InsurancePlan>(planDto);
            _planRepository.Add(plan);
            return plan.PlanId;
        }

        public void UpdatePlan(InsurancePlanDto planDto)
        {
            var updatedPlan = _mapper.Map<InsurancePlan>(planDto);
            var existingPlan = _planRepository.GetAll().AsNoTracking().FirstOrDefault(plan => updatedPlan.PlanId == plan.PlanId);
            if (existingPlan == null)
                throw new NotFoundException("InsurancePlan");
            _planRepository.Update(updatedPlan);
        }

        public void DeletePlan(Guid planId)
        {
            var plan = _planRepository.GetById(planId);
            if (plan == null)
                throw new NotFoundException("InsurancePlan");

            _planRepository.Delete(plan);
        }
    }
}
