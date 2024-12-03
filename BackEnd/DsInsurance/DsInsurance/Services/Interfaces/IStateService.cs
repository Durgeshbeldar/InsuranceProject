using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IStateService
    {
        List<StateDto> GetAllStates();
        StateDto GetStateById(Guid stateId);
        Guid AddState(StateDto stateDto);
        void UpdateState(StateDto stateDto);
        void DeleteState(Guid stateId);
    }
}
