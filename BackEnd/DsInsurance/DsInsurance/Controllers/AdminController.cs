using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = _adminService.GetAllAdmins();
            return Ok(new
            {
                Message = "Admins retrieved successfully.",
                Data = admins
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAdminById(Guid id)
        {
            var admin = _adminService.GetAdminById(id);
            return Ok(new
            {
                Message = "Admin retrieved successfully.",
                Data = admin
            });
        }

        [HttpPost]
        public IActionResult AddAdmin(AdminDto adminDto)
        {
            var adminId = _adminService.AddAdmin(adminDto);
            return Ok(new
            {
                Message = "Admin added successfully.",
                AdminId = adminId
            });
        }

        [HttpPut]
        public IActionResult UpdateAdmin(AdminDto adminDto)
        {
            _adminService.UpdateAdmin(adminDto);
            return Ok(new
            {
                Message = "Admin updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(Guid id)
        {
            _adminService.DeleteAdmin(id);
            return Ok(new
            {
                Message = "Admin deleted successfully."
            });
        }
    }
}
