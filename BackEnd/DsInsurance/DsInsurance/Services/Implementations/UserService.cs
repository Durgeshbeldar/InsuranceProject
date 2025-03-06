using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Claim = System.Security.Claims.Claim;

namespace DsInsurance.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IRepository<User> userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public (bool isAuthenticated, string token, string message, string roleName, Guid? userId) Authenticate(LoginDto loginDto)
        {
            var existingUser = _userRepository.GetAll()
                               .Include(user => user.Role)
                               .FirstOrDefault(user => loginDto.UserName == user.UserName);
         
            if (existingUser == null)
                return (false, null, "User Not Found.", null,null);

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, existingUser.Password))
                return (false, null, "Invalid password.", null,null);
            string token = CreateToken(existingUser);
            return (true, token, "Login successful.", existingUser.Role.RoleName, existingUser.UserId);
        }

        private string CreateToken(User user)
        {
            var roleName = user.Role.RoleName;
            List<Claim> claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Name,user.UserName),
                 new Claim(ClaimTypes.Role, roleName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //token construction
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            //generate the token
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll().Include(u => u.Documents).ToList();
            if (!users.Any())
                throw new NotFoundException("Users");

            return _mapper.Map<List<UserDto>>(users);
        }

        public UserDto GetUserById(Guid userId)
        {
            var user = _userRepository.GetAll().Include(u=>u.Documents).FirstOrDefault(u=> u.UserId == userId);
            if (user == null)
                throw new NotFoundException("User");

            return _mapper.Map<UserDto>(user);
        }

        public Guid AddUser(UserDto userDto)
        {
            if (_userRepository.GetAll().Any(user => user.UserName == userDto.UserName))
                throw new AlreadyExistsException("User", "UserName");

            if (_userRepository.GetAll().Any(user => user.Email == userDto.Email))
                throw new AlreadyExistsException("User", "Email");

            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = _mapper.Map<User>(userDto);
            _userRepository.Add(user);

            return user.UserId;
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _userRepository.GetAll().AsNoTracking().FirstOrDefault(u=> u.UserId == userDto.UserId);
            if (user == null)
                throw new NotFoundException("User");
            var updatedUser =  _mapper.Map<User>(userDto);
            _userRepository.Update(updatedUser);
        }

        public void DeleteUser(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                throw new NotFoundException("User");

            user.IsActive = false; 
            _userRepository.Update(user); 
        }

        public void HardDeleteUser(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if(user == null)
                throw new NotFoundException("User");
            _userRepository.Delete(user);
        }
    }
}