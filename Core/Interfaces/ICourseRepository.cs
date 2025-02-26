using Core.Models;

namespace Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task<List<Course>> GetByIdsAsync(List<Guid> ids);
        Task<Course> AddAsync(Course course);
        Task<bool> ExistsAsync(string name);
    }
}
