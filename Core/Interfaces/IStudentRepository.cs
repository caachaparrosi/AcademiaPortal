using Core.Models;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student?> GetByUserIdAsync(Guid id);
        Task<Student> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Guid studentId);
        Task<bool> ExistsAsync(string email);
        Task<IEnumerable<Student>> GetClassmatesAsync(Guid studentId);
    }
}
