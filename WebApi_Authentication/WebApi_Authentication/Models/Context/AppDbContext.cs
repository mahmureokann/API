using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi_Authentication.Models.Entity;

namespace WebApi_Authentication.Models.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.Connection.ConnectionString = "server=FATIH\\SQLEXPRESS;database=WebApiAuthDB;uid=sa;pwd=123";
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}