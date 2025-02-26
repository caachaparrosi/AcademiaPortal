using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CreateTeacherDto
    {
        [Required]
        public string Name { get; set; }
    }
}
