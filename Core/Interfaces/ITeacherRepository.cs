using Core.Models;

namespace Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(Guid id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task<bool> ExistsAsync(string name);
    }
}
