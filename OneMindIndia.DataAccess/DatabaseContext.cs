using Microsoft.EntityFrameworkCore;
using OneMindIndia.DataAccess.Entities;

namespace OneMindIndia.DataAccess
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base() { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = tcp:onemindindia.database.windows.net,1433; Initial Catalog = mysampleserverdb; Persist Security Info = False; User ID = nivedha; Password = nivebiju11@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
        //Add migration -> Add-Migration InitialCreate
        //Update database -> Update-Database
    }
}
