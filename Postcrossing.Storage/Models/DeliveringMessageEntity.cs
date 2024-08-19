using System.ComponentModel.DataAnnotations;

namespace Postcrossing.Storage.Models;

public class DeliveringMessageEntity
{
    public Guid Id { get; set; }
    
    public Guid SenderId { get; set; }
    public UserEntity Sender { get; set; }
    
    public Guid RecipientId { get; set; }
    public UserEntity Recipient { get; set; }
    
    public DateTimeOffset SentAt { get; set; }
    [MaxLength(10)]
    public string ActivationCode { get; set; }
}