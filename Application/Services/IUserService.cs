using Core.DTOs;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterUserDto registerUserDto);
        Task<UserDto?> GetUserByIdAsync(Guid userId);
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task DeleteUserAsync(Guid userId);
    }
}
