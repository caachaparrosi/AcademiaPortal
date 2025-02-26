using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(c => c.Program).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students.Include(c => c.Program).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Student?> GetByUserIdAsync(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Student> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _context.Students.AnyAsync(s => s.Email == email);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetClassmatesAsync(Guid studentId)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null || !student.Courses.Any())
                return new List<Student>(); // No tiene compañeros de clase

            var classmates = await _context.Students
                .Include(s => s.Courses)
                .Where(s => s.Id != studentId && s.Courses.Any(c => student.Courses.Select(sc => sc.Id).Contains(c.Id)))
                .ToListAsync();

            return classmates;
        }

        

    }
}
