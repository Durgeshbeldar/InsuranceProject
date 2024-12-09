using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IUserService
    {
        (bool isAuthenticated, string token, string message, string roleName, Guid? userId) Authenticate(LoginDto loginDto);
        List<UserDto> GetAllUsers();
        UserDto GetUserById(Guid userId);
        Guid AddUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        void DeleteUser(Guid userId);
        void HardDeleteUser(Guid userId);
    }
}
