namespace Postcrossing.Api.Models;

public class UserDto
{
    public string FistName { get; set; }
    public string LastName { get; set; }
    
    public AddressDto AddressDto { get; set; }
}