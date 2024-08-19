using System.ComponentModel.DataAnnotations;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Models;

public class UserEntity
{
    public Guid Id { get; set; }

    [MaxLength(50)] public string FirstName { get; set; } = "";
    [MaxLength(50)] public string LastName { get; set; } = "";
    
    public Guid AddressId { get; set; }
    public AddressEntity Address { get; set; }
    
    public ICollection<DeliveringMessageEntity> DispatchedMessage { get; set; }
    public ICollection<DeliveringMessageEntity> PendingMessages { get; set; }
    
    public ICollection<MessageQueueEntity> RequestMessages { get; set; }
    
    public ICollection<DeliveredMessageEntity> ReceivedMessages { get; set; }
    public ICollection<DeliveredMessageEntity> SentMessages { get; set; }
    
}