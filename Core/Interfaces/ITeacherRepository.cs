using Core.Models;

namespace Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(Guid id);
        Task<Teacher?> GetByUserIdAsync(Guid id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(Guid teacherId);
        Task<bool> ExistsAsync(string name);
    }
}
