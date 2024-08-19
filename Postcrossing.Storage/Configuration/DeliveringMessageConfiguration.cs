using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models;

namespace Postcrossing.Storage.Configuration;

public class DeliveringMessageConfiguration : IEntityTypeConfiguration<DeliveringMessageEntity>
{
    public void Configure(EntityTypeBuilder<DeliveringMessageEntity> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.HasOne(d => d.Sender)
            .WithMany(u => u.DispatchedMessage)
            .HasForeignKey(d=>d.SenderId);
        
        builder.HasOne(p => p.Recipient)
            .WithMany(u => u.PendingMessages)
            .HasForeignKey(p => p.RecipientId);
    }
}