using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Configuration;

public class DistrictConfiguration : IEntityTypeConfiguration<DistrictEntity>
{
    public void Configure(EntityTypeBuilder<DistrictEntity> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();

        builder.HasOne(d => d.County)
            .WithMany(c => c.Districts)
            .HasForeignKey(d => d.CountyId);
        
        builder.HasMany(d => d.Addresses)
            .WithOne(a => a.District);

        builder.HasMany(d => d.Cities)
            .WithOne(c => c.Distric);
    }
}