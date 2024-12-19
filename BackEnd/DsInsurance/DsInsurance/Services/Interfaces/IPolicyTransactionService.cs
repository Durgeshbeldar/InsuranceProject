using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IPolicyTransactionService
    {
        List<PolicyTransactionDto> GetAllTransactions();
        PolicyTransactionDto GetTransactionById(Guid transactionId);
        Guid AddTransaction(PolicyTransactionDto transactionDto);
        void UpdateTransaction(PolicyTransactionDto transactionDto);
        List<PolicyTransactionDto> GetAllTransactionsByUserId(Guid userId);
        public List<PolicyTransactionDto> GetAllTransactionsByCustomerId(Guid customerId);
    }
}
