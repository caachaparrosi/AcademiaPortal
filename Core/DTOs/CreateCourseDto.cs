using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CreateCourseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid TeacherId { get; set; }
    }
}
