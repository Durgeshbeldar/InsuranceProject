using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IAgentService
    {
        List<AgentDto> GetAllAgents();
        AgentDto GetAgentById(Guid agentId);
        Guid AddAgent(AgentDto agentDto);
        void UpdateAgent(AgentDto agentDto);
        void DeleteAgent(Guid agentId);
    }
}
