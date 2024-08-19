namespace Postcrossing.Storage.Models;

public class MessageQueueEntity
{
    public int Id { get; set; }
    
    public Guid RequestedUserId { get; set; }
    public UserEntity RequestedUser { get; set; }
}