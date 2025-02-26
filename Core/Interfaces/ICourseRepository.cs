using Core.Models;

namespace Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task<Course> AddAsync(Course course);
        Task<bool> ExistsAsync(string name);
    }
}
