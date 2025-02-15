using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateListing.Domain.Entities;

namespace RealEstateListing.Infrastructure.Data.Context.Configuration
{
    internal class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Id);
            modelBuilder.Property(b => b.Id).ValueGeneratedOnAdd();

            modelBuilder.Property(b => b.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            modelBuilder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Property(b => b.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        }
    }
}
