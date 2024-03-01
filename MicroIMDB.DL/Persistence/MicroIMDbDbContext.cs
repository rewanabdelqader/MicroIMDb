using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicroIMDb.Models;
using MicroIMDb.Infrastructure.Config;
using Microsoft.AspNetCore.Identity;

namespace MicroIMDb.Persistence
{
    public class MicroIMDbDbContext : IdentityDbContext<User>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public MicroIMDbDbContext(DbContextOptions<MicroIMDbDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RateConfig());
        }
    }
}
