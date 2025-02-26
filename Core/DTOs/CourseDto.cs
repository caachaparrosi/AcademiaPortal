namespace Core.DTOs
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string TeacherName { get; set; }
    }
}
