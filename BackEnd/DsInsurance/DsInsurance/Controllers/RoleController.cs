using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(new
            {
                Message = "Roles retrieved successfully.",
                Data = roles
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(Guid id)
        {
            var role = _roleService.GetRoleById(id);
            return Ok(new
            {
                Message = "Role retrieved successfully.",
                Data = role
            });
        }

        [HttpPost]
        public IActionResult Add(RoleDto roleDto)
        {
            var roleId = _roleService.AddRole(roleDto);
            return Ok(new
            {
                Message = $"Role Added Successfully with ID: {roleId}"
            });
        }

        [HttpPut]
        public IActionResult UpdateRole(RoleDto roleDto)
        {
            _roleService.UpdateRole(roleDto);
            return Ok(new
            {
                Message = "Role updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(Guid id)
        {
            _roleService.DeleteRole(id);
            return Ok(new
            {
                Message = "Role deleted successfully."
            });
        }
    }
}
