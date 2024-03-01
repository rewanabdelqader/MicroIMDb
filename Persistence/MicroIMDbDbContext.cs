using MicroIMDb.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroIMDb.Persistence
{
    public class MicroIMDbDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rate> Rates { get; set; } 

        public MicroIMDbDbContext(DbContextOptions<MicroIMDbDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Rate>(); 


            base.OnModelCreating(modelBuilder); 
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=192.168.100.255;Initial Catalog=microtec.ERPDatabase;User ID=Administrator; Password=Dev@2025;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=false;Connection Timeout=100");
        //}
    }
}