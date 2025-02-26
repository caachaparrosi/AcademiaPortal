using Core.DTOs;

namespace Application.Services
{
    public interface IProgramService
    {
        Task<IEnumerable<ProgramDto>> GetAllAsync();
        Task<ProgramDto?> GetByIdAsync(Guid id);
    }
}
