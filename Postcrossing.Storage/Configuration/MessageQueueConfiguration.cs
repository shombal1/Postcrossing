using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postcrossing.Storage.Models;

namespace Postcrossing.Storage.Configuration;

public class MessageQueueConfiguration : IEntityTypeConfiguration<MessageQueueEntity>
{
    public void Configure(EntityTypeBuilder<MessageQueueEntity> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();

        builder.HasOne(m => m.RequestedUser)
            .WithMany(u => u.RequestMessages)
            .HasForeignKey(m=>m.RequestedUserId);
    }
}