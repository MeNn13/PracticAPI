using Microsoft.EntityFrameworkCore;
using System;

namespace Practic.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
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
                    new User { Id = Guid.NewGuid().ToString(), First_name = "Екатерина", Midle_name = "Сергеевна", Last_name = "Потапенко", Login = "stud", Password = "st", Role = "Ученик" }
            );
        }
    }
}
