using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public UserService(IUserRepository userRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user == null ? null : new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
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

            // Si es estudiante, lo creamos automáticamente
            if (registerUserDto.Role == "Student")
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Name = user.Name,
                    Email = user.Email
                };
                await _studentRepository.AddAsync(student);
            }

            // Si es profesor, lo creamos automáticamente
            if (registerUserDto.Role == "Teacher")
            {
                var teacher = new Teacher
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Name = user.Name,
                };
                await _teacherRepository.AddAsync(teacher);
            }

            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Role = user.Role };
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(updateUserDto.Id);
            if (user == null)
                throw new Exception("Usuario no encontrado.");

            user.Name = updateUserDto.Name;
            user.Email = updateUserDto.Email;

            await _userRepository.UpdateAsync(user);

            // Editar también el estudiante o profesor asociado
            if (user.Role == "Student")
            {
                var student = await _studentRepository.GetByUserIdAsync(user.Id);
                if (student != null)
                {
                    student.Name = user.Name;
                    student.Email = user.Email;
                    await _studentRepository.UpdateAsync(student);
                }
            }
            else if (user.Role == "Teacher")
            {
                var teacher = await _teacherRepository.GetByUserIdAsync(user.Id);
                if (teacher != null)
                {
                    teacher.Name = user.Name;
                    await _teacherRepository.UpdateAsync(teacher);
                }
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("Usuario no encontrado.");

            // Eliminar también el estudiante o profesor asociado
            if (user.Role == "Student")
            {
                var student = await _studentRepository.GetByUserIdAsync(user.Id);
                if (student != null)
                    await _studentRepository.DeleteAsync(student.Id);
            }
            else if (user.Role == "Teacher")
            {
                var teacher = await _teacherRepository.GetByUserIdAsync(user.Id);
                if (teacher != null)
                    await _teacherRepository.DeleteAsync(teacher.Id);
            }

            await _userRepository.DeleteAsync(userId);
        }
    }
}
