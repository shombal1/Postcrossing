namespace Postcrossing.Storage.Models.Address;

public class ResidentialAddressEntity
{
    public Guid Id { get; set; }
    
    public int CountryId { get; set; }
    public CountryEntity Country { get; set; }
    public int DistrictId { get; set; }
    public DistrictEntity District { get; set; }
    public int CityId { get; set; }
    public CityEntity City { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}