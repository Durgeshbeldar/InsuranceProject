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


        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var (isAuthenticated, token, message, roleName, userId) = _userService.Authenticate(loginDto);

            if (!isAuthenticated)
                return BadRequest(new { message });

            Response.Headers.Add("Jwt", token);
            return Ok(new
            {
                message = "Login successful.",
                roleName,
                userId,
            });
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
                Message = "User Added Successfully",
                Id = userId
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

        [HttpDelete("User/{id}")]
        public IActionResult RemoveUser(Guid id)
        {
            _userService.HardDeleteUser(id);
            return Ok(new
            {
                Message = "User Deleted Successfully"
            });
        }
    }
}
