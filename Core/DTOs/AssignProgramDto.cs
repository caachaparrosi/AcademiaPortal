using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class AssignProgramDto
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid ProgramId { get; set; }
    }
}
