using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("Student|Teacher", ErrorMessage = "El rol debe ser 'Student' o 'Teacher'.")]
        public string Role { get; set; }
    }
}
