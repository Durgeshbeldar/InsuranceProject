using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        private readonly IInstallmentService _installmentService;

        public InstallmentController(IInstallmentService installmentService)
        {
            _installmentService = installmentService;
        }

        [HttpGet]
        public IActionResult GetAllInstallments()
        {
            var installments = _installmentService.GetAllInstallments();
            return Ok(new
            {
                Message = "Installments retrieved successfully.",
                Data = installments
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetInstallmentById(Guid id)
        {
            var installment = _installmentService.GetInstallmentById(id);
            return Ok(new
            {
                Message = "Installment retrieved successfully.",
                Data = installment
            });
        }

        [HttpPost]
        public IActionResult AddInstallment(InstallmentDto installmentDto)
        {
            var installmentId = _installmentService.AddInstallment(installmentDto);
            return Ok(new
            {
                Message = "Installment added successfully.",
                InstallmentId = installmentId
            });
        }

        [HttpPut]
        public IActionResult UpdateInstallment(InstallmentDto installmentDto)
        {
            _installmentService.UpdateInstallment(installmentDto);
            return Ok(new
            {
                Message = "Installment updated successfully."
            });
        }
    }
}
