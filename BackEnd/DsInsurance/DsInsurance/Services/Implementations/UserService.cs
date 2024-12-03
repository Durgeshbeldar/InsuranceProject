using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll().ToList();
            if (!users.Any())
                throw new NotFoundException("Users");

            return _mapper.Map<List<UserDto>>(users);
        }

        public UserDto GetUserById(Guid userId)
        {
            var user = _userRepository.GetById(userId);
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
            var user = _userRepository.GetById(userDto.UserId.Value);
            if (user == null)
                throw new NotFoundException("User");

            if (user.UserName != userDto.UserName &&
              _userRepository.GetAll().Any(user => user.UserName == userDto.UserName))
                throw new AlreadyExistsException("User", "UserName");

            if (user.Email != userDto.Email &&
              _userRepository.GetAll().Any(user => user.Email == userDto.Email))
                throw new AlreadyExistsException("User", "Email");

            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var updatedUser = _mapper.Map<User>(userDto);
            _userRepository.Update(updatedUser);
        }

        public void DeleteUser(Guid userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException("User");

            _userRepository.Delete(user);
        }
    }
}