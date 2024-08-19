namespace Postcrossing.Domain.Authentication;

public class User : IIdentity
{
    public Guid Id { get; set; }
}