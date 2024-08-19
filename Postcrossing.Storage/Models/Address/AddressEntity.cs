namespace Postcrossing.Storage.Models.Address;

public class AddressEntity
{
    public Guid Id { get; set; }
    
    public int CountyId { get; set; }
    public CountyEntity Country { get; set; }
    public int DistrictId { get; set; }
    public DistrictEntity District { get; set; }
    public int CityId { get; set; }
    public CityEntity City { get; set; }
    
    public ICollection<UserEntity> Users { get; set; }
}