using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Program> Program { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inicializar Programas
            modelBuilder.Entity<Program>().HasData(
                new Program { Id = Guid.Parse("03911B56-3375-489A-A60F-E7AA7FFBD045"), Name = "Ingeniería de Sistemas", TotalCredits = 60 },
                new Program { Id = Guid.Parse("AC4A1F8D-7B99-4708-9E00-0807DFFF45CD"), Name = "Medicina", TotalCredits = 70 },
                new Program { Id = Guid.Parse("5E9EE734-61A9-4BD8-9298-D0D0F5F67D3F"), Name = "Derecho", TotalCredits = 50 }
            );

            // Inicializar Profesores
            var teachers = new List<Teacher>
            {
                new Teacher { Id = Guid.Parse("AE9A6102-0905-4BF1-8D2F-72E74E820B0C"), Name = "Profesor A" },
                new Teacher { Id = Guid.Parse("8A9A9AF4-2AFE-42F4-97DC-60122239279B"), Name = "Profesor B" },
                new Teacher { Id = Guid.Parse("A9976D54-FEDB-43F9-9015-25A960704818"), Name = "Profesor C" },
                new Teacher { Id = Guid.Parse("5639E743-26BF-4E1E-BC99-A075EE33B30F"), Name = "Profesor D" },
                new Teacher { Id = Guid.Parse("FB038367-2884-45CD-B1FF-A9F1D1308F7A"), Name = "Profesor E" }
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);


            // Inicializar Materias
            var courses = new List<Course>
            {
                new Course { Id = Guid.Parse("13E02595-F92E-48D5-B3F2-690CCDF32BC1"), Name = "Matemáticas", Credits = 3, TeacherId = teachers[0].Id },
                new Course { Id = Guid.Parse("40BDB71D-EE7C-470E-AEC1-E05F17DF9BA6"), Name = "Física", Credits = 3, TeacherId = teachers[0].Id },
                new Course { Id = Guid.Parse("7F7B440F-BAEF-4D9F-B18A-609C38677571"), Name = "Química", Credits = 3, TeacherId = teachers[1].Id },
                new Course { Id = Guid.Parse("1C930008-353A-4AE4-A6F0-987603CB68C5"), Name = "Biología", Credits = 3, TeacherId = teachers[1].Id },
                new Course { Id = Guid.Parse("CE9E4D5C-F4CA-4F3B-92F0-94E9573F1007"), Name = "Programación", Credits = 3, TeacherId = teachers[2].Id },
                new Course { Id = Guid.Parse("DB5076B2-31FC-4562-AFC5-8C6AB833033F"), Name = "Bases de Datos", Credits = 3, TeacherId = teachers[2].Id },
                new Course { Id = Guid.Parse("FE336441-9557-4170-AA43-EBC0EE483783"), Name = "Economía", Credits = 3, TeacherId = teachers[3].Id },
                new Course { Id = Guid.Parse("AC1A1770-E185-4A1C-85ED-74BA3F3C85DB"), Name = "Contabilidad", Credits = 3, TeacherId = teachers[3].Id },
                new Course { Id = Guid.Parse("015028D8-8E9A-4175-A56C-9DF28E44FCE4"), Name = "Psicología", Credits = 3, TeacherId = teachers[4].Id },
                new Course { Id = Guid.Parse("C081A086-5B8F-469A-BDBF-DDBECC5FBA59"), Name = "Derecho", Credits = 3, TeacherId = teachers[4].Id }
            };
            modelBuilder.Entity<Course>().HasData(courses);
        }
    }
}
