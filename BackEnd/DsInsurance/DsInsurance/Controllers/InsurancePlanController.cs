using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePlanController : ControllerBase
    {
        private readonly IInsurancePlanService _planService;

        public InsurancePlanController(IInsurancePlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public IActionResult GetAllPlans()
        {
            var plans = _planService.GetAllPlans();
            return Ok(new
            {
                Message = "Insurance plans retrieved successfully.",
                Data = plans
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(Guid id)
        {
            var plan = _planService.GetPlanById(id);
            return Ok(new
            {
                Message = "Insurance plan retrieved successfully.",
                Data = plan
            });
        }

        [HttpPost]
        public IActionResult AddPlan(InsurancePlanDto planDto)
        {
            var planId = _planService.AddPlan(planDto);
            return Ok(new
            {
                Message = "Insurance plan added successfully.",
                PlanId = planId
            });
        }

        [HttpPut]
        public IActionResult UpdatePlan(InsurancePlanDto planDto)
        {
            _planService.UpdatePlan(planDto);
            return Ok(new
            {
                Message = "Insurance plan updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlan(Guid id)
        {
            _planService.DeletePlan(id);
            return Ok(new
            {
                Message = "Insurance plan deleted successfully."
            });
        }
    }
}
