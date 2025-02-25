using Core.Models;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student> AddAsync(Student student);
        Task<bool> ExistsAsync(string email);
    }
}
