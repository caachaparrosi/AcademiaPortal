namespace Core.Models
{
    public class Program
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalCredits { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}