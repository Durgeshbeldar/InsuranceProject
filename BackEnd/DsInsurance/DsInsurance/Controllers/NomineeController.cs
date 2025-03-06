using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomineeController : ControllerBase
    {
        private readonly INomineeService _nomineeService;

        public NomineeController(INomineeService nomineeService)
        {
            _nomineeService = nomineeService;
        }

        [HttpGet]
        public IActionResult GetAllNominees()
        {
            var nominees = _nomineeService.GetAllNominees();
            return Ok(new
            {
                Message = "Nominees retrieved successfully.",
                Data = nominees
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetNomineeById(Guid id)
        {
            var nominee = _nomineeService.GetNomineeById(id);
            return Ok(new
            {
                Message = "Nominee retrieved successfully.",
                Data = nominee
            });
        }
        [HttpGet("Policy/{policyNo}")]
        public IActionResult GetNomineeByPolicyNo(Guid policyNo)
        {
            var nominee = _nomineeService.GetNomineeByPolicyNo(policyNo);
            return Ok(new
            {
                Message = "Nominee retrieved successfully.",
                Data = nominee
            });
        }

        [HttpPost]
        public IActionResult AddNominee(NomineeDto nomineeDto)
        {
            var nomineeId = _nomineeService.AddNominee(nomineeDto);
            return Ok(new
            {
                Message = "Nominee added successfully.",
                NomineeId = nomineeId
            });
        }

        [HttpPut]
        public IActionResult UpdateNominee(NomineeDto nomineeDto)
        {
            _nomineeService.UpdateNominee(nomineeDto);
            return Ok(new
            {
                Message = "Nominee updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNominee(Guid id)
        {
            _nomineeService.DeleteNominee(id);
            return Ok(new
            {
                Message = "Nominee deleted successfully."
            });
        }
    }
}
