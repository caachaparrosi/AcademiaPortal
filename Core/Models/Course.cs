namespace Core.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; } = 3;
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
