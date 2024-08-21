using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<ResidentialAddressEntity>
{
    public void Configure(EntityTypeBuilder<ResidentialAddressEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Country)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CountryId);
        
        builder.HasOne(a => a.District)
            .WithMany(d => d.Addresses)
            .HasForeignKey(a => a.DistrictId);
        
        builder.HasOne(a => a.City)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CityId);
       
        builder.HasOne(a => a.User)
            .WithOne(u => u.ResidentialAddress)
            .HasForeignKey<ResidentialAddressEntity>(a=>a.UserId);
    }
}