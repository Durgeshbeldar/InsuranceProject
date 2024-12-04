using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class AgentService : IAgentService
    {
        private readonly IRepository<Agent> _agentRepository;
        private readonly IMapper _mapper;

        public AgentService(IRepository<Agent> agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        public List<AgentDto> GetAllAgents()
        {
            var agents = _agentRepository.GetAll().ToList();
            if (!agents.Any())
                throw new NotFoundException("Agents");

            return _mapper.Map<List<AgentDto>>(agents);
        }

        public AgentDto GetAgentById(Guid agentId)
        {
            var agent = _agentRepository.GetById(agentId);
            if (agent == null)
                throw new NotFoundException("Agent");

            return _mapper.Map<AgentDto>(agent);
        }

        public Guid AddAgent(AgentDto agentDto)
        {
            var agent = _mapper.Map<Agent>(agentDto);
            _agentRepository.Add(agent);
            return agent.AgentId;
        }

        public void UpdateAgent(AgentDto agentDto)
        {
            var existingAgent = _agentRepository.GetById(agentDto.AgentId);
            if (existingAgent == null)
                throw new NotFoundException("Agent");

            var agent = _mapper.Map<Agent>(agentDto);
            _agentRepository.Update(agent);
        }

        public void DeleteAgent(Guid agentId)
        {
            var agent = _agentRepository.GetById(agentId);
            if (agent == null)
                throw new NotFoundException("Agent");

            _agentRepository.Delete(agent);
        }
    }
}
