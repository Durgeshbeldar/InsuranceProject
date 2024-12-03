using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        public IActionResult GetAllAgents()
        {
            var agents = _agentService.GetAllAgents();
            return Ok(new
            {
                Message = "Agents retrieved successfully.",
                Data = agents
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAgentById(Guid id)
        {
            var agent = _agentService.GetAgentById(id);
            return Ok(new
            {
                Message = "Agent retrieved successfully.",
                Data = agent
            });
        }

        [HttpPost]
        public IActionResult AddAgent(AgentDto agentDto)
        {
            var agentId = _agentService.AddAgent(agentDto);
            return Ok(new
            {
                Message = "Agent added successfully.",
                AgentId = agentId
            });
        }

        [HttpPut]
        public IActionResult UpdateAgent(AgentDto agentDto)
        {
            _agentService.UpdateAgent(agentDto);
            return Ok(new
            {
                Message = "Agent updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAgent(Guid id)
        {
            _agentService.DeleteAgent(id);
            return Ok(new
            {
                Message = "Agent deleted successfully."
            });
        }
    }
}
