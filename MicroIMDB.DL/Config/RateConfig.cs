using MicroIMDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroIMDb.Infrastructure.Config
{
    public class RateConfig : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(r => r.Id);

            //builder.HasOne(r => r.User)
            //    .WithMany(u => u.Rates)
            //    .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Movie)
                .WithMany(m => m.Rates)
                .HasForeignKey(r => r.MovieId);
        }
    }
}
