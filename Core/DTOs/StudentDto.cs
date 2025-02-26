namespace Core.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProgramName { get; set; }
        public int AvailableCredits { get; set; }        
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
}
