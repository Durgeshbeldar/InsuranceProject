using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class PolicyTransactionService : IPolicyTransactionService
    {
        private readonly IRepository<PolicyTransaction> _transactionRepository;
        private readonly IMapper _mapper;

        public PolicyTransactionService(IRepository<PolicyTransaction> transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public List<PolicyTransactionDto> GetAllTransactions()
        {
            var transactions = _transactionRepository.GetAll().Include(pt => pt.PolicyAccount).ToList();
            if (!transactions.Any())
                throw new NotFoundException("PolicyTransactions");

            return _mapper.Map<List<PolicyTransactionDto>>(transactions);
        }
        public List<PolicyTransactionDto> GetAllTransactionsByUserId(Guid userId)
        {
            var transactions = _transactionRepository.GetAll().Include(pt => pt.PolicyAccount)
                .Where(pt=> pt.UserId == userId).ToList();
            if (!transactions.Any())
                throw new NotFoundException("PolicyTransactions");

            return _mapper.Map<List<PolicyTransactionDto>>(transactions);
        }

        public List<PolicyTransactionDto> GetAllTransactionsByCustomerId(Guid customerId)
        {
            var transactions = _transactionRepository.GetAll().Include(pt => pt.PolicyAccount)
                .Where(pt => pt.PolicyAccount.CustomerId == customerId).ToList();
            if (!transactions.Any())
                throw new NotFoundException("PolicyTransactions");

            return _mapper.Map<List<PolicyTransactionDto>>(transactions);
        }
        public PolicyTransactionDto GetTransactionById(Guid transactionId)
        {
            var transaction = _transactionRepository.GetById(transactionId);
            if (transaction == null)
                throw new NotFoundException("PolicyTransaction");

            return _mapper.Map<PolicyTransactionDto>(transaction);
        }

        public Guid AddTransaction(PolicyTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<PolicyTransaction>(transactionDto);
            _transactionRepository.Add(transaction);
            return transaction.TransactionId;
        }


        public void UpdateTransaction(PolicyTransactionDto transactionDto)
        {
            var updatedTransaction = _mapper.Map<PolicyTransaction>(transactionDto);
            var existingTransaction = _transactionRepository.GetAll()
                .AsNoTracking()
                .FirstOrDefault(transaction => updatedTransaction.TransactionId == transaction.TransactionId);

            if (existingTransaction == null)
                throw new NotFoundException("PolicyTransaction");

            _transactionRepository.Update(updatedTransaction);
        }
    }
}
