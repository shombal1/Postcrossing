using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Postcrossing.Storage.Models;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage;

public class PostcrossingDbContext(DbContextOptions<PostcrossingDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DeliveringMessageEntity> DeliveringMessages { get; set; }
    public DbSet<MessageQueueEntity> QueueMessages { get; set; }
    public DbSet<DeliveredMessageEntity> DeliveredMessages { get; set; }
    
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CountyEntity> Countries { get; set; }
    public DbSet<DistrictEntity> Districts { get; set; }
    public DbSet<CityEntity> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PostcrossingDbContext))!);

        base.OnModelCreating(modelBuilder);
    }
}