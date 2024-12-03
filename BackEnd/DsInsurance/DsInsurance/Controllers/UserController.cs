using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(new
            {
                Message = "Users retrieved successfully.",
                Data = users
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);
            return Ok(new
            {
                Message = "User retrieved successfully.",
                Data = user
            });
        }

      
        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            var userId = _userService.AddUser(userDto);
            return Ok(new
            {
                Message = $"User Added Successfully with ID: {userId}"
            });
        }


        [HttpPut]
        public IActionResult UpdateUser(UserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return Ok(new
            {
                Message = "User updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userService.DeleteUser(id);
            return Ok(new
            {
                Message = "User deleted successfully."
            });
        }
    }
}
