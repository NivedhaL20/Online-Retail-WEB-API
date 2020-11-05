using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OneMindIndia.DataAccess.Entities;
using System;

namespace OneMindIndia.DataAccess
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //Add migration -> Add-Migration InitialCreate
        //Update database -> Update-Database
    }
}
