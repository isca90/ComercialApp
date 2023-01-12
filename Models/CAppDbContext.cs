using CommercialApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CommercialApp.Models
{
    public class CAppDbContext : DbContext
    {

        public CAppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Singular>();
            modelBuilder.Entity<Company>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<People> People { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Singular> Singular { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<CommercialApp.Models.TransactionDetail> TransactionDetail { get; set; }


    }
}
public static class CAppDbInit
{

    public static void Seed(this CAppDbContext dbContext)
    {

        dbContext.Database.EnsureCreated();
        if (!dbContext.People.Any())
        {
            Singular s1 = new Singular()
            {
                Name = "admin",
                Email = "admin@email.com",
                NIF = "123123",
                Username = "admin",
                Password = "admin",
                Address = "Rua dos admins n1",
                PostalCode = "1234-231",
                City = "Cidade dos admins",
                PhoneNumber = "914568541",
            };

            dbContext.People.Add(s1);


            dbContext.SaveChanges();

        }

    }
}
