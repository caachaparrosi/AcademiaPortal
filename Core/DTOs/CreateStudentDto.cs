using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
