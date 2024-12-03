using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class StateService : IStateService
    {
        private readonly IRepository<State> _stateRepository;
        private readonly IMapper _mapper;

        public StateService(IRepository<State> stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        public List<StateDto> GetAllStates()
        {
            var states = _stateRepository.GetAll().ToList();
            if (!states.Any())
                throw new NotFoundException("States");

            return _mapper.Map<List<StateDto>>(states);
        }

        public StateDto GetStateById(Guid stateId)
        {
            var state = _stateRepository.GetById(stateId);
            if (state == null)
                throw new NotFoundException("State");

            return _mapper.Map<StateDto>(state);
        }

        public Guid AddState(StateDto stateDto)
        {
            var state = _mapper.Map<State>(stateDto);
            _stateRepository.Add(state);

            return state.StateId;
        }

        public void UpdateState(StateDto stateDto)
        {
            var state = _stateRepository.GetById(stateDto.StateId.Value);
            if (state == null)
                throw new NotFoundException("State");

            state = _mapper.Map<State>(stateDto);
            _stateRepository.Update(state);
        }

        public void DeleteState(Guid stateId)
        {
            var state = _stateRepository.GetById(stateId);
            if (state == null)
                throw new NotFoundException("State");

            _stateRepository.Delete(state);
        }
    }
}
