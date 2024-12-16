using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IWithdrawRequestService
    {
        List<WithdrawalRequestDto> GetAllRequests();
        WithdrawalRequestDto GetRequestById(Guid requestId);
        Guid AddWithdrawalRequest(WithdrawalRequestDto withdrawalRequestDto);
        void UpdateWithdrawalRequest(WithdrawalRequestDto withdrawalRequestDto);
        void DeleteWithdrawalRequest(Guid requestId);
    }
}
