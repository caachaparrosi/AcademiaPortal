namespace Core.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public Guid? ProgramId { get; set; }
        public Program? Program { get; set; }
        public int AvailableCredits { get; set; }
    }
}
