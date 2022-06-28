using Agora.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.DAL.Initializer
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            string pwd = BCrypt.Net.BCrypt.HashPassword("123");
            modelBuilder.Entity<User>().HasData(
               new User() { ID = 1, UserName = "admin", Password = pwd, Role = MODEL.Enums.Role.Admin },
               new User() { ID = 2, UserName = "esra", Password = pwd, Role = MODEL.Enums.Role.Admin }
          );
        }
    }
}
