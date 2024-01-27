using AssignmentDTwo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace NewSecond.Data
{
    //public class ApplicationUser : IdentityUser
    public class AppDbContext : IdentityDbContext //<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorksFor> WorksFors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Attendance> Attendances { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ABDULLAH;Initial Catalog=DTwo;Integrated Security=True");
            
            //optionsBuilder.LogTo(log => Debug.WriteLine(log));

            //optionsBuilder.UseLazyLoadingProxies(true);

            base.OnConfiguring(optionsBuilder);
        }


        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data Annotation Faster in this case
            modelBuilder.Entity<Department>().ToTable("Department"); 
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<WorksFor>().ToTable("WorksFor");
            modelBuilder.Entity<Attendance>().ToTable("Attendance");
            modelBuilder.Entity<Attendance>().ToTable("Attendance");
            modelBuilder.Entity<Trainee>().ToTable("Trainee");
            modelBuilder.Entity<Course>().ToTable("Course");


            modelBuilder.Entity<Department>().Property(e => e.Name).IsRequired(true);
            modelBuilder.Entity<Instructor>().Property(e => e.Name).IsRequired(true);
            modelBuilder.Entity<Trainee>().Property(e => e.Name).IsRequired(true);
            modelBuilder.Entity<Course>().Property(e => e.Name).IsRequired(true);


            modelBuilder.Entity<Attendance>().HasKey(e => new { e.TraineeID, e.Date });
            modelBuilder.Entity<Attendance>().HasKey(e => new { e.InstructorID, e.Date });


            modelBuilder.Entity<Account>()
            .HasOne(a => a.Instructor)
            .WithOne(a => a.Account)
            .HasForeignKey<Account>(c => c.InstructorID);


            //modelBuilder.Entity<Instructor>().HasQueryFilter(e => !e.IsDeleted);

            // Shadow Property
            //modelBuilder.Entity<Department>()
            //    .Property<bool>("IsDeleted").IsRequired(true).HasDefaultValue(false);

            // Shadow Property for all entities
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(item.Name).Property<bool>("IsDeleted")
                    .IsRequired(true).HasDefaultValue(false);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
