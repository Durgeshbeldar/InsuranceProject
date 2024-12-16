using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawalRequestController : ControllerBase
    {
        private readonly IWithdrawRequestService _withdrawalRequestService;

        public WithdrawalRequestController(IWithdrawRequestService withdrawalRequestService)
        {
            _withdrawalRequestService = withdrawalRequestService;
        }

        [HttpGet]
        public IActionResult GetAllRequests()
        {
            var requests = _withdrawalRequestService.GetAllRequests();
            return Ok(new
            {
                Message = "Withdrawal requests retrieved successfully.",
                Data = requests
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetRequestById(Guid id)
        {
            var request = _withdrawalRequestService.GetRequestById(id);
            return Ok(new
            {
                Message = "Withdrawal request retrieved successfully.",
                Data = request
            });
        }

        [HttpPost]
        public IActionResult AddWithdrawalRequest(WithdrawalRequestDto withdrawalRequestDto)
        {
            var requestId = _withdrawalRequestService.AddWithdrawalRequest(withdrawalRequestDto);
            return Ok(new
            {
                Message = "Withdrawal request added successfully.",
                RequestId = requestId
            });
        }

        [HttpPut]
        public IActionResult UpdateWithdrawalRequest(WithdrawalRequestDto withdrawalRequestDto)
        {
            _withdrawalRequestService.UpdateWithdrawalRequest(withdrawalRequestDto);
            return Ok(new
            {
                Message = "Withdrawal request updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWithdrawalRequest(Guid id)
        {
            _withdrawalRequestService.DeleteWithdrawalRequest(id);
            return Ok(new
            {
                Message = "Withdrawal request deleted successfully."
            });
        }
    }
}
