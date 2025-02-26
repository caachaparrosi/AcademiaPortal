using Core.DTOs;

namespace Application.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(Guid id);
        Task<CourseDto> CreateAsync(CreateCourseDto courseDto);
    }
}
