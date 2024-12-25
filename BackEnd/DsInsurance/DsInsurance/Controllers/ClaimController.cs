using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public IActionResult GetAllClaims()
        {
            var claims = _claimService.GetAllClaims();
            return Ok(new
            {
                Message = "Claims retrieved successfully.",
                Data = claims
            });
        }

        [HttpGet("Customer/{customerId}")]
        public IActionResult GetClaimsByCustomerId(Guid customerId)
        {
            var claims = _claimService.GetClaimsByCustomerId(customerId);
            return Ok(new
            {
                Message = "Claims retrieved successfully.",
                Data = claims
            });
        }


        [HttpGet("{id}")]
        public IActionResult GetClaimById(Guid id)
        {
            var claim = _claimService.GetClaimById(id);
            return Ok(new
            {
                Message = "Claim retrieved successfully.",
                Data = claim
            });
        }

        [HttpPost]
        public IActionResult AddClaim(ClaimDto claimDto)
        {
            var claimId = _claimService.AddClaim(claimDto);
            return Ok(new
            {
                Message = "Claim submitted successfully.",
                ClaimId = claimId
            });
        }

        [HttpPut]
        public IActionResult UpdateClaim(ClaimDto claimDto)
        {
            _claimService.UpdateClaim(claimDto);
            return Ok(new
            {
                Message = "Claim updated successfully."
            });
        }

        
    }
}
