using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers.Select(t => new TeacherDto { Id = t.Id, Name = t.Name });
        }

        public async Task<TeacherDto?> GetByIdAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            return teacher == null ? null : new TeacherDto { Id = teacher.Id, Name = teacher.Name };
        }

        public async Task<TeacherDto> CreateAsync(CreateTeacherDto teacherDto)
        {
            if (await _teacherRepository.ExistsAsync(teacherDto.Name))
                throw new Exception("El profesor ya existe.");

            var teacher = new Teacher { Id = Guid.NewGuid(), Name = teacherDto.Name };
            teacher = await _teacherRepository.AddAsync(teacher);

            return new TeacherDto { Id = teacher.Id, Name = teacher.Name };
        }
    }
}
