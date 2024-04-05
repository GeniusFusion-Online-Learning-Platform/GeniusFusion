using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 

namespace GeniusFusion_GroupProject.Entities
{  


    public class GeniusFusionDbContext: DbContext
    {
        public GeniusFusionDbContext(DbContextOptions<GeniusFusionDbContext> options) : base(options)
        {

        } 
        public DbSet <Course> Courses { get; set; }
        public DbSet <Faculty> Faculties { get; set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.CourseId, e.StudentId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            // Configure one-to-many relationship between Course and Faculty
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Faculty)
                .WithMany(f => f.CoursesTaught)
                .HasForeignKey(c => c.FacultyId);
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed courses
            

            // Seed faculties
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { FacultyId = 1, FacultyName = "Peter Mazdiak", dateOfBirth = new DateTime(1985, 5, 31), FacultyPhone = "1234567890", FacultyAddress="Waterloo, ON", FacultyEmail = "peter@geniusFusion.edu"},
                new Faculty { FacultyId = 2, FacultyName = "Eliott Coleshill", dateOfBirth= new DateTime(1999, 6, 18), FacultyPhone = "2223334465", FacultyAddress = "Kitchener, ON",  FacultyEmail = "Eliott@geniusFusion.edu" }
                
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Enterprise Application Development", FacultyId = 1 },
                new Course { CourseId = 2, CourseName = "Software Quality", FacultyId = 2 }

            );
            // Seed students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Bob Martin", dateOfBirth = new DateTime(2002, 8, 31), StudentPhone = "3336664478", StudentAddress = "Waterloo, ON",  StudentEmail = "Bob@geniusfusion.edu" }, 
                new Student { StudentId = 2, StudentName = "Jake Alace", dateOfBirth = new DateTime(2001, 7, 25), StudentPhone = "4445557789", StudentAddress = "Kitchener, ON",  StudentEmail = "Jake@geniusfusion.edu" }
                
            );

            // Seed enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { CourseId = 1, StudentId = 1 },
                new Enrollment { CourseId = 1, StudentId = 2 },
                new Enrollment { CourseId = 2, StudentId = 1 }
                
            );
        }
    }
}
