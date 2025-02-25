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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = Guid.Parse("03911B56-3375-489A-A60F-E7AA7FFBD045"), Name = "Profesor 1" },
                new Teacher { Id = Guid.Parse("5E9EE734-61A9-4BD8-9298-D0D0F5F67D3F"), Name = "Profesor 2" }
            );
        }
    }
}
