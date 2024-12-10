using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class PolicyCoverageService : IPolicyCoverageService
    {
        private readonly IRepository<PolicyCoverage> _coverageRepository;
        private readonly IMapper _mapper;

        public PolicyCoverageService(IRepository<PolicyCoverage> coverageRepository, IMapper mapper)
        {
            _coverageRepository = coverageRepository;
            _mapper = mapper;
        }

        public List<PolicyCoverageDto> GetAllPolicyCoverages()
        {
            var coverages = _coverageRepository.GetAll().Include(pc => pc.PolicyAccount).ToList();
            if (!coverages.Any())
                throw new NotFoundException("PolicyCoverages");

            return _mapper.Map<List<PolicyCoverageDto>>(coverages);
        }

        public PolicyCoverageDto GetPolicyCoverageById(Guid coverageId)
        {
            var coverage = _coverageRepository.GetById(coverageId);
            if (coverage == null)
                throw new NotFoundException("PolicyCoverage");

            return _mapper.Map<PolicyCoverageDto>(coverage);
        }

        public Guid AddPolicyCoverage(PolicyCoverageDto coverageDto)
        {
            var coverage = _mapper.Map<PolicyCoverage>(coverageDto);
            _coverageRepository.Add(coverage);
            return coverage.CoverageId;
        }

        public void UpdatePolicyCoverage(PolicyCoverageDto coverageDto)
        {
            var updatedCoverage = _mapper.Map<PolicyCoverage>(coverageDto);
            var existingCoverage = _coverageRepository.GetAll().AsNoTracking().FirstOrDefault(c => updatedCoverage.CoverageId == c.CoverageId);
            if (existingCoverage == null)
                throw new NotFoundException("PolicyCoverage");
            _coverageRepository.Update(updatedCoverage);
        }

      
    }
}
