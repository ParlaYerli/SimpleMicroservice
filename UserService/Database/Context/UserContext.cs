using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Database.Entities;

namespace UserService.Database.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=UserMicro; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Name = "Azra", Address= "Karaşar" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, Name = "Hazal", Address = "Ankara" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, Name = "Parla", Address = "İstanbul" });
        }
    }
}
