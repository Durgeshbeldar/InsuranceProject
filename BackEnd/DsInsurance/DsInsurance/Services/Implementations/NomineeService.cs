using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class NomineeService : INomineeService
    {
        private readonly IRepository<Nominee> _nomineeRepository;
        private readonly IMapper _mapper;

        public NomineeService(IRepository<Nominee> nomineeRepository, IMapper mapper)
        {
            _nomineeRepository = nomineeRepository;
            _mapper = mapper;
        }

        public List<NomineeDto> GetAllNominees()
        {
            var nominees = _nomineeRepository.GetAll().ToList();
            if (!nominees.Any())
                throw new NotFoundException("Nominees");

            return _mapper.Map<List<NomineeDto>>(nominees);
        }

        public NomineeDto GetNomineeById(Guid nomineeId)
        {
            var nominee = _nomineeRepository.GetById(nomineeId);
            if (nominee == null)
                throw new NotFoundException("Nominee");

            return _mapper.Map<NomineeDto>(nominee);
        }

        public Guid AddNominee(NomineeDto nomineeDto)
        {
            var nominee = _mapper.Map<Nominee>(nomineeDto);
            _nomineeRepository.Add(nominee);
            return nominee.NomineeId;
        }

        public void UpdateNominee(NomineeDto nomineeDto)
        {
            var existingNominee = _nomineeRepository.GetById(nomineeDto.NomineeId.Value);
            if (existingNominee == null)
                throw new NotFoundException("Nominee");

            var nominee = _mapper.Map<Nominee>(nomineeDto);
            _nomineeRepository.Update(nominee);
        }

        public void DeleteNominee(Guid id)
        {
            var nominee = _nomineeRepository.GetById(id);
            if (nominee == null)
                throw new NotFoundException("Nominee");

            nominee.IsActive = false;
            _nomineeRepository.Update(nominee);
        }
    }
}
