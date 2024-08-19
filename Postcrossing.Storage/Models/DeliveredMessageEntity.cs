namespace Postcrossing.Storage.Models;

public class DeliveredMessageEntity
{
    public Guid Id { get; set; }
    
    public DateTimeOffset ReceivedAt { get; set; }
    public DateTimeOffset SentAt { get; set; }
    
    public Guid RecipientId { get; set; }
    public UserEntity Recipient { get; set; }
    
    public Guid SenderId { get; set; }
    public UserEntity Sender { get; set; }
    
}