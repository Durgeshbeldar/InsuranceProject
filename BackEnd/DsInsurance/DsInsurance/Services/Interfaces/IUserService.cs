using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        UserDto GetUserById(Guid userId);
        Guid AddUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        void DeleteUser(Guid userId);
    }
}
