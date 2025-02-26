using Core.DTOs;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterUserDto registerUserDto);
    }
}
