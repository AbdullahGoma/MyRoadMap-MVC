using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewSecond.Models;

namespace NewSecond.Data
{
    public class AppDbContext : IdentityDbContext 
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ABDULLAH;Initial Catalog=SNew;Integrated Security=True");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
