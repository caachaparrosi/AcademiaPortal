using Core.Models;

namespace Core.Interfaces
{
    public interface IProgramRepository
    {
        Task<IEnumerable<Program>> GetAllAsync();
        Task<Program?> GetByIdAsync(Guid id);
    }
}
