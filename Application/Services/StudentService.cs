using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(s => new StudentDto { Id = s.Id, Name = s.Name, Email = s.Email });
        }

        public async Task<StudentDto?> GetByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student == null ? null : new StudentDto { Id = student.Id, Name = student.Name, Email = student.Email };
        }

        public async Task<StudentDto> CreateAsync(CreateStudentDto studentDto)
        {
            if (await _studentRepository.ExistsAsync(studentDto.Email))
                throw new Exception("El email ya está registrado.");

            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = studentDto.Name,
                Email = studentDto.Email
            };

            student = await _studentRepository.AddAsync(student);
            return new StudentDto { Id = student.Id, Name = student.Name, Email = student.Email };
        }
    }
}
