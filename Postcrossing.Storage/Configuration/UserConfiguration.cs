using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models;

namespace Postcrossing.Storage.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.Address)
            .WithMany(a => a.Users)
            .HasForeignKey(u => u.AddressId);
        
        builder.HasMany(u => u.RequestMessages)
            .WithOne(m => m.RequestedUser);
        
        builder.HasMany(u => u.DispatchedMessage)
            .WithOne(d => d.Sender);
        builder.HasMany(u => u.PendingMessages)
            .WithOne(d => d.Recipient);

        builder.HasMany(u => u.SentMessages)
            .WithOne(s => s.Sender);
        builder.HasMany(u => u.ReceivedMessages)
            .WithOne(u => u.Recipient);
    }
}