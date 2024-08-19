using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<CityEntity>
{
    public void Configure(EntityTypeBuilder<CityEntity> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.Distric)
            .WithMany(d => d.Cities)
            .HasForeignKey(c=>c.DistrictId);
        
        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.City);
    }
}