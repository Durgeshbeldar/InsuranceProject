using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceSchemeController : ControllerBase
    {
        private readonly IInsuranceSchemeService _schemeService;

        public InsuranceSchemeController(IInsuranceSchemeService schemeService)
        {
            _schemeService = schemeService;
        }

        [HttpGet]
        public IActionResult GetAllSchemes()
        {
            var schemes = _schemeService.GetAllSchemes();
            return Ok(new
            {
                Message = "Insurance schemes retrieved successfully.",
                Data = schemes
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetSchemeById(Guid id)
        {
            var scheme = _schemeService.GetSchemeById(id);
            return Ok(new
            {
                Message = "Insurance scheme retrieved successfully.",
                Data = scheme
            });
        }
        [HttpGet("/Plan/{planId}")]
        public IActionResult GetSchemeByPlanId(Guid planId)
        {
            var schemes = _schemeService.getSchemesByPlanId(planId);
            return Ok(new
            {
                Message = "Insurance schemes retrieved successfully.",
                Data = schemes
            });
        }



        [HttpPost]
        public IActionResult AddScheme(InsuranceSchemeDto schemeDto)
        {
            var schemeId = _schemeService.AddScheme(schemeDto);
            return Ok(new
            {
                Message = "Insurance scheme added successfully.",
                SchemeId = schemeId
            });
        }

        [HttpPut]
        public IActionResult UpdateScheme(InsuranceSchemeDto schemeDto)
        {
            _schemeService.UpdateScheme(schemeDto);
            return Ok(new
            {
                Message = "Insurance scheme updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteScheme(Guid id)
        {
            _schemeService.DeleteScheme(id);
            return Ok(new
            {
                Message = "Insurance scheme deleted successfully."
            });
        }
    }
}
