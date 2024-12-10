using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class InstallmentService : IInstallmentService
    {
        private readonly IRepository<Installment> _installmentRepository;
        private readonly IMapper _mapper;

        public InstallmentService(IRepository<Installment> installmentRepository, IMapper mapper)
        {
            _installmentRepository = installmentRepository;
            _mapper = mapper;
        }

        public List<InstallmentDto> GetAllInstallments()
        {
            var installments = _installmentRepository.GetAll().ToList();
            if (!installments.Any())
                throw new NotFoundException("Installments");

            return _mapper.Map<List<InstallmentDto>>(installments);
        }

        public InstallmentDto GetInstallmentById(Guid id)
        {
            var installment = _installmentRepository.GetById(id);
            if (installment == null)
                throw new NotFoundException("Installment");

            return _mapper.Map<InstallmentDto>(installment);
        }

        public Guid AddInstallment(InstallmentDto installmentDto)
        {
            var installment = _mapper.Map<Installment>(installmentDto);
            _installmentRepository.Add(installment);
            return installment.InstallmentId;
        }

        public void UpdateInstallment(InstallmentDto installmentDto)
        {
            var updatedInstallment = _mapper.Map<Installment>(installmentDto);
            var existingInstallment = _installmentRepository.GetAll().AsNoTracking().FirstOrDefault(inst => updatedInstallment.InstallmentId == inst.InstallmentId);
            if (existingInstallment == null)
                throw new NotFoundException("Installment");

            _installmentRepository.Update(updatedInstallment);
        }
    }
}
