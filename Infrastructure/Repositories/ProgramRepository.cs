using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly AppDbContext _context;

        public ProgramRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Program>> GetAllAsync()
        {
            return await _context.Program.ToListAsync();
        }

        public async Task<Program?> GetByIdAsync(Guid id)
        {
            return await _context.Program.FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
