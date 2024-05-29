using Jit.Models;
using Microsoft.EntityFrameworkCore;


namespace Jit.Context
{
    public class MyDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Visit>? Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Jit;Trusted_Connection=True;");
        }
        
    }
}
