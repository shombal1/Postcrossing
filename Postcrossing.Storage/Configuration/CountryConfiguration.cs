using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<CountyEntity>
{
    public void Configure(EntityTypeBuilder<CountyEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(c => c.Addresses)
            .WithOne(a => a.Country);

        builder.HasMany(c => c.Districts)
            .WithOne(d => d.County);
    }
}