using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Country)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CountyId);
        
        builder.HasOne(a => a.District)
            .WithMany(d => d.Addresses)
            .HasForeignKey(a => a.DistrictId);
        
        builder.HasOne(a => a.City)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CityId);
    }
}