using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyCoverageController : ControllerBase
    {
        private readonly IPolicyCoverageService _coverageService;

        public PolicyCoverageController(IPolicyCoverageService coverageService)
        {
            _coverageService = coverageService;
        }

        [HttpGet]
        public IActionResult GetAllPolicyCoverages()
        {
            var coverages = _coverageService.GetAllPolicyCoverages();
            return Ok(new
            {
                Message = "Policy coverages retrieved successfully.",
                Data = coverages
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetPolicyCoverageById(Guid id)
        {
            var coverage = _coverageService.GetPolicyCoverageById(id);
            return Ok(new
            {
                Message = "Policy coverage retrieved successfully.",
                Data = coverage
            });
        }

        [HttpPost]
        public IActionResult AddPolicyCoverage(PolicyCoverageDto coverageDto)
        {
            var coverageId = _coverageService.AddPolicyCoverage(coverageDto);
            return Ok(new
            {
                Message = "Policy coverage added successfully.",
                CoverageId = coverageId
            });
        }

        [HttpPut]
        public IActionResult UpdatePolicyCoverage(PolicyCoverageDto coverageDto)
        {
            _coverageService.UpdatePolicyCoverage(coverageDto);
            return Ok(new
            {
                Message = "Policy coverage updated successfully."
            });
        }

     
    }
}
