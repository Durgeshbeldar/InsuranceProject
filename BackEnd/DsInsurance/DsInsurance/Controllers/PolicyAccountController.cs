using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyAccountController : ControllerBase
    {
        private readonly IPolicyAccountService _policyAccountService;

        public PolicyAccountController(IPolicyAccountService policyAccountService)
        {
            _policyAccountService = policyAccountService;
        }

        [HttpGet]
        public IActionResult GetAllPolicyAccounts()
        {
            var policyAccounts = _policyAccountService.GetAllPolicyAccounts();
            return Ok(new
            {
                Message = "Policy accounts retrieved successfully.",
                Data = policyAccounts
            });
        }

        [HttpGet("Customer/{customerId}")]

        public IActionResult GetPolicyAccountsByCustomerId(Guid customerId)
        {
            var policyAccounts = _policyAccountService.GetAllPolicyAccountsByCustomerId(customerId);
            return Ok(new
            {
                Message = "Policy accounts retrieved successfully.",
                Data = policyAccounts
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetPolicyAccountById(Guid id)
        {
            var policyAccount = _policyAccountService.GetPolicyAccountById(id);
            return Ok(new
            {
                Message = "Policy account retrieved successfully.",
                Data = policyAccount
            });
        }

        [HttpPost]
        public IActionResult AddPolicyAccount(PolicyAccountDto policyAccountDto)
        {
            var policyAccountId = _policyAccountService.AddPolicyAccount(policyAccountDto);
            return Ok(new
            {
                Message = "Policy account added successfully.",
                PolicyAccountId = policyAccountId
            });
        }

        [HttpPut("/Status")]
        public IActionResult ChangePolicyStatus (PolicyApprovedDto policyApprovedDto)
        {
            var isChanged = _policyAccountService.ChangePolicyStatus(policyApprovedDto);
            return Ok(new
            {
                Message = "Policy Status is Changed",
                IsChanged = isChanged
            });

        }

        [HttpPut]
        public IActionResult UpdatePolicyAccount(PolicyAccountDto policyAccountDto)
        {
            _policyAccountService.UpdatePolicyAccount(policyAccountDto);
            return Ok(new
            {
                Message = "Policy account updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePolicyAccount(Guid id)
        {
            _policyAccountService.DeletePolicyAccount(id);
            return Ok(new
            {
                Message = "Policy account deleted successfully."
            });
        }
    }
}
