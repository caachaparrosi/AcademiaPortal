using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> RegisterAsync(RegisterUserDto registerUserDto)
        {
            if (await _userRepository.GetByEmailAsync(registerUserDto.Email) != null)
                throw new Exception("El email ya está registrado.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = registerUserDto.Name,
                Email = registerUserDto.Email,
                Role = registerUserDto.Role
            };

            user = await _userRepository.AddAsync(user);
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Role = user.Role };
        }
    }
}
