using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Admin> _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IRepository<Admin> adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public List<AdminDto> GetAllAdmins()
        {
            var admins = _adminRepository.GetAll().Include(ad=> ad.User).ToList();
            if (!admins.Any())
                throw new NotFoundException("Admins");

            return _mapper.Map<List<AdminDto>>(admins);
        }

        public AdminDto GetAdminById(Guid adminId)
        {
            var admin = _adminRepository.GetById(adminId);
            if (admin == null)
                throw new NotFoundException("Admin");

            return _mapper.Map<AdminDto>(admin);
        }

        public Guid AddAdmin(AdminDto adminDto)
        {
            var admin = _mapper.Map<Admin>(adminDto);
            _adminRepository.Add(admin);
            return admin.AdminId;
        }

        public void UpdateAdmin(AdminDto adminDto)
        {
            var existingAdmin = _adminRepository.GetById(adminDto.AdminId);
            if (existingAdmin == null)
                throw new NotFoundException("Admin");

            var admin = _mapper.Map<Admin>(adminDto);
            _adminRepository.Update(admin);
        }

        public void DeleteAdmin(Guid adminId)
        {
            var admin = _adminRepository.GetById(adminId);
            if (admin == null)
                throw new NotFoundException("Admin");

            _adminRepository.Delete(admin);
        }
    }
}
