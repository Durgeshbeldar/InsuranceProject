using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IRepository<Claim> _claimRepository;
        private readonly IMapper _mapper;

        public ClaimService(IRepository<Claim> claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public List<ClaimDto> GetAllClaims()
        {
            var claims = _claimRepository.GetAll()
                .Include(c => c.PolicyAccount)
                .Include(c => c.Customer)
           
                .ToList();

            if (!claims.Any())
                throw new NotFoundException("Claims");

            return _mapper.Map<List<ClaimDto>>(claims);
        }
        public List<ClaimDto> GetClaimsByCustomerId(Guid customerId)
        {
            var claims = GetAllClaims().Where(claim => claim.CustomerId == customerId).ToList();
            if (!claims.Any())
                throw new NotFoundException("Claims");
            return claims;
        }

        public ClaimDto GetClaimById(Guid claimId)
        {
            var claim = _claimRepository.GetAll()
                .Include(c => c.PolicyAccount)
                .Include(c => c.Customer)
        
                .FirstOrDefault(c => c.ClaimId == claimId);

            if (claim == null)
                throw new NotFoundException("Claim");

            return _mapper.Map<ClaimDto>(claim);
        }

        public Guid AddClaim(ClaimDto claimDto)
        {
            var claim = _mapper.Map<Claim>(claimDto);
            _claimRepository.Add(claim);
            return claim.ClaimId;
        }

        public void UpdateClaim(ClaimDto claimDto)
        {
            var updatedClaim = _mapper.Map<Claim>(claimDto);
            var existingClaim = _claimRepository.GetAll().AsNoTracking().FirstOrDefault(c => updatedClaim.ClaimId == c.ClaimId);

            if (existingClaim == null)
                throw new NotFoundException("Claim");

            _claimRepository.Update(updatedClaim);
        }

        public void DeleteClaim(Guid claimId)
        {
            var claim = _claimRepository.GetById(claimId);

            if (claim == null)
                throw new NotFoundException("Claim");

            _claimRepository.Delete(claim);
        }
    }
}
