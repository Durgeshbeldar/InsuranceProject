using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

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
            var existingScheme = _schemeRepository.GetById(schemeDto.SchemeId.Value);
            if (existingScheme == null)
                throw new NotFoundException("InsuranceScheme");

            var scheme = _mapper.Map<InsuranceScheme>(schemeDto);
            _schemeRepository.Update(scheme);
        }

        public void DeleteInsuranceScheme(Guid schemeId)
        {
            var scheme = _schemeRepository.GetById(schemeId);
            if (scheme == null)
                throw new NotFoundException("Insurance Scheme");

            scheme.IsActive = false;
            _schemeRepository.Update(scheme);
        }
    }
}
