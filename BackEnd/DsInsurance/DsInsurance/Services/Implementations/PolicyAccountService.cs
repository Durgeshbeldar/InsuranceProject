﻿using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class PolicyAccountService : IPolicyAccountService
    {
        private readonly IRepository<PolicyAccount> _policyAccountRepository;
        private readonly IMapper _mapper;

        public PolicyAccountService(IRepository<PolicyAccount> policyAccountRepository, IMapper mapper)
        {
            _policyAccountRepository = policyAccountRepository;
            _mapper = mapper;
        }

        public List<PolicyAccountDto> GetAllPolicyAccounts()
        {
            var policyAccounts = _policyAccountRepository.GetAll()
                .Include(pa => pa.Customer).ThenInclude(customer => customer.Documents)
                .Include(pa => pa.Agent)
                .Include(pa => pa.InsuranceScheme)
                .Include(pa => pa.PolicyCoverages)
                .Include(pa => pa.Installments)
                .Include(pa => pa.PolicyTransactions)
                .Include(pa => pa.Nominees)
                .ToList();

            if (!policyAccounts.Any())
                throw new NotFoundException("PolicyAccounts");

            return _mapper.Map<List<PolicyAccountDto>>(policyAccounts);
        }
        public List<PolicyAccountDto> GetAllPolicyAccountsByCustomerId(Guid customerId)
        {
            var policyAccounts = _policyAccountRepository.GetAll().Where(pa =>pa.CustomerId == customerId)
                .Include(pa => pa.Customer).ThenInclude(c => c.Documents)
                .Include(pa => pa.Agent)
                .Include(pa => pa.InsuranceScheme)
                .Include(pa => pa.PolicyCoverages)
                .Include(pa => pa.Installments)
                .Include(pa => pa.PolicyTransactions)
                .Include(pa => pa.Nominees)
                .ToList();

            if (!policyAccounts.Any())
                throw new NotFoundException("PolicyAccounts");

            return _mapper.Map<List<PolicyAccountDto>>(policyAccounts);
        }

        public PolicyAccountDto GetPolicyAccountById(Guid policyAccountId)
        {
            var policyAccount = _policyAccountRepository.GetAll()
                .Include(pa => pa.Customer)
                .Include(pa => pa.Agent)
                .Include(pa => pa.InsuranceScheme)
                .Include(pa => pa.PolicyCoverages)
                .Include(pa => pa.Installments)
                .Include(pa => pa.PolicyTransactions)
                .Include(pa => pa.Nominees)
                .FirstOrDefault(pa => pa.PolicyNo == policyAccountId);

            if (policyAccount == null)
                throw new NotFoundException("PolicyAccount");

            return _mapper.Map<PolicyAccountDto>(policyAccount);
        }

        public bool ChangePolicyStatus(PolicyApprovedDto policyApprovedDto)
        {
               var existingPolicyAccount = _policyAccountRepository.GetAll()
                .AsNoTracking().FirstOrDefault(policy => policy.PolicyNo == policyApprovedDto.PolicyNo);
            if (existingPolicyAccount == null)
                throw new NotFoundException("Policy");
            if(policyApprovedDto.IssueDate != null)
            existingPolicyAccount.IssueDate = policyApprovedDto.IssueDate;
            existingPolicyAccount.Status = policyApprovedDto.Status;
            existingPolicyAccount.IsApproved = (bool) policyApprovedDto.IsApproved;
            if (policyApprovedDto.MaturityDate != null)
                existingPolicyAccount.MaturityDate = (DateTime)policyApprovedDto.MaturityDate;
            _policyAccountRepository.Update(existingPolicyAccount); 
            return true;
        }
        
        
        public Guid AddPolicyAccount(PolicyAccountDto policyAccountDto)
        {
            var policyAccount = _mapper.Map<PolicyAccount>(policyAccountDto);
            _policyAccountRepository.Add(policyAccount);
            return policyAccount.PolicyNo;
        }
        
        public void UpdatePolicyAccount(PolicyAccountDto policyAccountDto)
        {
            var updatedPolicyAccount = _mapper.Map<PolicyAccount>(policyAccountDto);
            var existingPolicyAccount = _policyAccountRepository.GetAll()
                .AsNoTracking()
                .FirstOrDefault(pa => pa.PolicyNo == updatedPolicyAccount.PolicyNo);

            if (existingPolicyAccount == null)
                throw new NotFoundException("PolicyAccount");

            _policyAccountRepository.Update(updatedPolicyAccount);
        }

        public void DeletePolicyAccount(Guid policyAccountId)
        {
            var policyAccount = _policyAccountRepository.GetById(policyAccountId);
            if (policyAccount == null)
                throw new NotFoundException("PolicyAccount");

            policyAccount.IsActive = false;
            _policyAccountRepository.Update(policyAccount);
        }
    }
}
