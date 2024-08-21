namespace Postcrossing.Domain.Models;

public class ResidentialAddress
{
    public Guid Id { get; set; }
    public string Code { get; set; } = "";
    public string County { get; set; } = "";
    public string District { get; set; } = "";
    public string City { get; set; } = "";
}