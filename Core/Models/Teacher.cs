namespace Core.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
