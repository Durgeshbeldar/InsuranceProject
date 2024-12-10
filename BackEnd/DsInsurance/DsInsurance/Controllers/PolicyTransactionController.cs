using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyTransactionController : ControllerBase
    {
        private readonly IPolicyTransactionService _transactionService;

        public PolicyTransactionController(IPolicyTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(new
            {
                Message = "Policy transactions retrieved successfully.",
                Data = transactions
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionById(Guid id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            return Ok(new
            {
                Message = "Policy transaction retrieved successfully.",
                Data = transaction
            });
        }

        [HttpPost]
        public IActionResult AddTransaction(PolicyTransactionDto transactionDto)
        {
            var transactionId = _transactionService.AddTransaction(transactionDto);
            return Ok(new
            {
                Message = "Policy transaction added successfully.",
                TransactionId = transactionId
            });
        }

        [HttpPut]
        public IActionResult UpdateTransaction(PolicyTransactionDto transactionDto)
        {
            _transactionService.UpdateTransaction(transactionDto);
            return Ok(new
            {
                Message = "Policy transaction updated successfully."
            });
        }

    }
}
