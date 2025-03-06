using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface INomineeService
    {
        List<NomineeDto> GetAllNominees();
        NomineeDto GetNomineeById(Guid nomineeId);
        Guid AddNominee(NomineeDto nomineeDto);
        void UpdateNominee(NomineeDto nomineeDto);
        void DeleteNominee(Guid nomineeId);
        public NomineeDto GetNomineeByPolicyNo(Guid policyNo);
    }
}
