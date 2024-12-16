using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IPolicyAccountService
    {
        List<PolicyAccountDto> GetAllPolicyAccounts();
        PolicyAccountDto GetPolicyAccountById(Guid policyAccountId);
        Guid AddPolicyAccount(PolicyAccountDto policyAccountDto);
        void UpdatePolicyAccount(PolicyAccountDto policyAccountDto);
        void DeletePolicyAccount(Guid policyAccountId);
        public bool ChangePolicyStatus(PolicyApprovedDto policyApprovedDto);
        public List<PolicyAccountDto> GetAllPolicyAccountsByCustomerId(Guid customerId);
    }
}
