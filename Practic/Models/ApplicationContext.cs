using Microsoft.EntityFrameworkCore;
using System;

namespace Practic.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Classroom> classrooms { get; set; }
        public DbSet<Timetable> timetables { get; set; }
        public DbSet<Subject> subjects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Андрей", Midle_name = "Андреевич", Last_name = "Андреев", Login = "Admin", Password = "ad", Role = "Администратор" },
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Сидор", Midle_name = "Сидорович", Last_name = "Сидоров", Login = "zav", Password = "12", Role = "Завуч" },
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Наталья", Midle_name = "Николаевна", Last_name = "Владимирова", Login = "teach", Password = "tch", Role = "Учитель" },
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Петр", Midle_name = "Петрович", Last_name = "Петров", Login = "Per", Password = "pr", Role = "Родитель" },
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Екатерина", Midle_name = "Сергеевна", Last_name = "Потапенко", Login = "stud", Password = "st", Role = "Ученик" });

            modelBuilder.Entity<Class>().HasData(
                    new Class { Id = Guid.NewGuid().ToString(), Number = 1, Letter = "а"},
                    new Class { Id = Guid.NewGuid().ToString(), Number = 1, Letter = "б"},
                    new Class { Id = Guid.NewGuid().ToString(), Number = 5, Letter = "а"});

            modelBuilder.Entity<Classroom>().HasData(
                    new Classroom { Id = Guid.NewGuid().ToString(), Number = 101 },
                    new Classroom { Id = Guid.NewGuid().ToString(), Number = 105},
                    new Classroom { Id = Guid.NewGuid().ToString(), Number = 103});

            modelBuilder.Entity<Subject>().HasData(
                    new Subject { Id = Guid.NewGuid().ToString(), Name = "Математика"},
                    new Subject { Id = Guid.NewGuid().ToString(), Name = "Русский язык"},
                    new Subject { Id = Guid.NewGuid().ToString(), Name = "История"});
        }
    }
}
