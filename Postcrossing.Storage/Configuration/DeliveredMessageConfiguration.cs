using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models;

namespace Postcrossing.Storage.Configuration;

public class DeliveredMessageConfiguration : IEntityTypeConfiguration<DeliveredMessageEntity>
{
    public void Configure(EntityTypeBuilder<DeliveredMessageEntity> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(r=>r.SenderId);
        
        builder.HasOne(r => r.Recipient)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(r=>r.RecipientId);
    }
}