namespace Core.DTOs
{
    public class StudentListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProgramName { get; set; } // Muestra el programa al que pertenece
    }
}
