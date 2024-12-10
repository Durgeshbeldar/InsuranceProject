using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IPolicyTransactionService
    {
        List<PolicyTransactionDto> GetAllTransactions();
        PolicyTransactionDto GetTransactionById(Guid transactionId);
        Guid AddTransaction(PolicyTransactionDto transactionDto);
        void UpdateTransaction(PolicyTransactionDto transactionDto);
    }
}
