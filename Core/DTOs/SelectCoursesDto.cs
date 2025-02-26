using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class SelectCoursesDto
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(3, ErrorMessage = "Un estudiante solo puede seleccionar hasta 3 materias.")]
        public List<Guid> CourseIds { get; set; } = new List<Guid>();
    }
}
