using ChatApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Kelvin", Email = "a@a.a" , salary = 20000},
                new Employee { Id = 2, Name = "Surya", Email = "b@b.b", salary = 30000 },
                new Employee { Id = 3, Name = "Xyz", Email = "c@c.c", salary = 40000 }
                );
        }
    }
}
