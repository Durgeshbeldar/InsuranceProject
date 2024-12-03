using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public IActionResult GetAllStates()
        {
            var states = _stateService.GetAllStates();
            return Ok(new
            {
                Message = "States retrieved successfully.",
                Data = states
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetStateById(Guid id)
        {
            var state = _stateService.GetStateById(id);
            return Ok(new
            {
                Message = "State retrieved successfully.",
                Data = state
            });
        }

        [HttpPost]
        public IActionResult AddState(StateDto stateDto)
        {
            var stateId = _stateService.AddState(stateDto);
            return Ok(new
            {
                Message = $"State Added Successfully with ID: {stateId}"
            });

        }

        [HttpPut]
        public IActionResult UpdateState(StateDto stateDto)
        {
            _stateService.UpdateState(stateDto);
            return Ok(new
            {
                Message = "State updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteState(Guid id)
        {
            _stateService.DeleteState(id);
            return Ok(new
            {
                Message = "State deleted successfully."
            });
        }
    }
}
