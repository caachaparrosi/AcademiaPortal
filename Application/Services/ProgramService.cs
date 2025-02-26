using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IEnumerable<ProgramDto>> GetAllAsync()
        {
            var programs = await _programRepository.GetAllAsync();
            return programs.Select(t => new ProgramDto { Id = t.Id, Name = t.Name, TotalCredits = t.TotalCredits });
        }

        public async Task<ProgramDto?> GetByIdAsync(Guid id)
        {
            var program = await _programRepository.GetByIdAsync(id);
            return program == null ? null : new ProgramDto { Id = program.Id, Name = program.Name, TotalCredits = program.TotalCredits };
        }

    }
}
