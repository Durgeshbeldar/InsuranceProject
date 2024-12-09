using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class InsuranceSchemeService : IInsuranceSchemeService
    {
        private readonly IRepository<InsuranceScheme> _schemeRepository;
        private readonly IMapper _mapper;

        public InsuranceSchemeService(IRepository<InsuranceScheme> schemeRepository, IMapper mapper)
        {
            _schemeRepository = schemeRepository;
            _mapper = mapper;
        }

        public List<InsuranceSchemeDto> GetAllSchemes()
        {
            var schemes = _schemeRepository.GetAll().ToList();
            if (!schemes.Any())
                throw new NotFoundException("InsuranceSchemes");

            return _mapper.Map<List<InsuranceSchemeDto>>(schemes);
        }

        public InsuranceSchemeDto GetSchemeById(Guid schemeId)
        {
            var scheme = _schemeRepository.GetById(schemeId);
            if (scheme == null)
                throw new NotFoundException("InsuranceScheme");

            return _mapper.Map<InsuranceSchemeDto>(scheme);
        }

        public Guid AddScheme(InsuranceSchemeDto schemeDto)
        {
            var scheme = _mapper.Map<InsuranceScheme>(schemeDto);
            _schemeRepository.Add(scheme);
            return scheme.SchemeId;
        }

        public void UpdateScheme(InsuranceSchemeDto schemeDto)
        {
            var updatedScheme = _mapper.Map<InsuranceScheme>(schemeDto);
            var existingScheme = _schemeRepository.GetAll().AsNoTracking().FirstOrDefault(scheme => updatedScheme.SchemeId == scheme.SchemeId);
            if (existingScheme == null)
                throw new NotFoundException("InsuranceScheme");
            _schemeRepository.Update(updatedScheme);
        }

        public void DeleteScheme(Guid schemeId)
        {
            var scheme = _schemeRepository.GetById(schemeId);
            if (scheme == null)
                throw new NotFoundException("Insurance Scheme");

            scheme.IsActive = false;
            _schemeRepository.Update(scheme);
        }
    }
}
