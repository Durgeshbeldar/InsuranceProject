using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class WithdrawRequestService : IWithdrawRequestService
    {
        private readonly IRepository<WithdrawalRequest> _withdrawalRequestRepository;
        private readonly IMapper _mapper;

        public WithdrawRequestService(IRepository<WithdrawalRequest> withdrawalRequestRepository, IMapper mapper)
        {
            _withdrawalRequestRepository = withdrawalRequestRepository;
            _mapper = mapper;
        }

        public List<WithdrawalRequestDto> GetAllRequests()
        {
            var requests = _withdrawalRequestRepository.GetAll().Include(wr => wr.Agent).ToList();
            if (!requests.Any())
                throw new NotFoundException("WithdrawalRequests");

            return _mapper.Map<List<WithdrawalRequestDto>>(requests);
        }

        public WithdrawalRequestDto GetRequestById(Guid requestId)
        {
            var request = _withdrawalRequestRepository.GetById(requestId);
            if (request == null)
                throw new NotFoundException("WithdrawalRequest");

            return _mapper.Map<WithdrawalRequestDto>(request);
        }

        public Guid AddWithdrawalRequest(WithdrawalRequestDto withdrawalRequestDto)
        {
            var withdrawalRequest = _mapper.Map<WithdrawalRequest>(withdrawalRequestDto);
            _withdrawalRequestRepository.Add(withdrawalRequest);
            return withdrawalRequest.WithdrawalRequestId;
        }

        public void UpdateWithdrawalRequest(WithdrawalRequestDto withdrawalRequestDto)
        {
            var updatedRequest = _mapper.Map<WithdrawalRequest>(withdrawalRequestDto);
            var existingRequest = _withdrawalRequestRepository.GetAll().AsNoTracking().FirstOrDefault(wr => wr.WithdrawalRequestId == updatedRequest.WithdrawalRequestId);
            if (existingRequest == null)
                throw new NotFoundException("WithdrawalRequest");
            _withdrawalRequestRepository.Update(updatedRequest);
        }

        public void DeleteWithdrawalRequest(Guid requestId)
        {
            var request = _withdrawalRequestRepository.GetById(requestId);
            if (request == null)
                throw new NotFoundException("WithdrawalRequest");

            _withdrawalRequestRepository.Delete(request);
        }
    }
}
