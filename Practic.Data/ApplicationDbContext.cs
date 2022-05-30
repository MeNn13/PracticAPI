using Microsoft.EntityFrameworkCore;
using Practic.Models;
using System;

namespace Practic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<Classroom> classrooms { get; set; }
        public DbSet<Timetable> timetables { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Role> roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Андрей", Midle_name = "Андреевич", Last_name = "Андреев", Login = "Admin", Password = "ad", RoleId = 1},
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Сидор", Midle_name = "Сидорович", Last_name = "Сидоров", Login = "zav", Password = "12", RoleId = 2 },
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Наталья", Midle_name = "Николаевна", Last_name = "Владимирова", Login = "teach", Password = "tch", RoleId = 3},
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Петр", Midle_name = "Петрович", Last_name = "Петров", Login = "Per", Password = "pr", RoleId = 4},
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Екатерина", Midle_name = "Сергеевна", Last_name = "Потапенко", Login = "stud", Password = "st", RoleId = 5});

            modelBuilder.Entity<Class>().HasData(
                    new Class { Id = Guid.NewGuid().ToString(), Number = 1, Letter = "а" },
                    new Class { Id = Guid.NewGuid().ToString(), Number = 1, Letter = "б" },
                    new Class { Id = Guid.NewGuid().ToString(), Number = 5, Letter = "а" });

            modelBuilder.Entity<Classroom>().HasData(
                    new Classroom { Id = Guid.NewGuid().ToString(), Number = 101 },
                    new Classroom { Id = Guid.NewGuid().ToString(), Number = 105 },
                    new Classroom { Id = Guid.NewGuid().ToString(), Number = 103 });

            modelBuilder.Entity<Subject>().HasData(
                    new Subject { Id = Guid.NewGuid().ToString(), Name = "Математика" },
                    new Subject { Id = Guid.NewGuid().ToString(), Name = "Русский язык" },
                    new Subject { Id = Guid.NewGuid().ToString(), Name = "История" });

            modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, Name = "Admin" },
                    new Role { Id = 2, Name = "Head teacher" },
                    new Role { Id = 3, Name = "Teacher" },
                    new Role { Id = 4, Name = "Parent" },
                    new Role { Id = 5, Name = "Student" });

        }
    }
}
