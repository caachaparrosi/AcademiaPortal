using Core.DTOs;

namespace Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(Guid id);
        Task<StudentDto> CreateAsync(CreateStudentDto studentDto);
    }
}
