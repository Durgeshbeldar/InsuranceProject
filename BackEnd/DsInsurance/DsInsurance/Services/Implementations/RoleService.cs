using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<RoleDto> GetAllRoles()
        {
            var roles = _roleRepository.GetAll().ToList();
            if (!roles.Any())
                throw new NotFoundException("Roles");

            return _mapper.Map<List<RoleDto>>(roles);
        }

        public RoleDto GetRoleById(Guid roleId)
        {
            var role = _roleRepository.GetById(roleId);
            if (role == null)
                throw new NotFoundException("Role");

            return _mapper.Map<RoleDto>(role);
        }

        public Guid AddRole(RoleDto roleDto)
        {
            if (_roleRepository.GetAll().Any(r => r.RoleName == roleDto.RoleName))
                throw new AlreadyExistsException("Role", "RoleName");

            var role = _mapper.Map<Role>(roleDto);
            _roleRepository.Add(role);

            return role.RoleId;
        }

        public void UpdateRole(RoleDto roleDto)
        {
            var role = _roleRepository.GetById(roleDto.RoleId.Value);
            if (role == null)
                throw new NotFoundException("Role");

            if (role.RoleName != roleDto.RoleName &&
                _roleRepository.GetAll().Any(r => r.RoleName == roleDto.RoleName))
                throw new AlreadyExistsException("Role", "RoleName");

            role = _mapper.Map<Role>(roleDto);
            _roleRepository.Update(role);
        }

        public void DeleteRole(Guid roleId)
        {
            var role = _roleRepository.GetById(roleId);
            if (role == null)
                throw new NotFoundException("Role");

            _roleRepository.Delete(role);
        }
    }
}
