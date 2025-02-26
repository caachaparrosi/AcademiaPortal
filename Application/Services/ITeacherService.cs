using Core.DTOs;

namespace Application.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task<TeacherDto?> GetByIdAsync(Guid id);
        Task<TeacherDto> CreateAsync(CreateTeacherDto teacherDto);
    }
}
