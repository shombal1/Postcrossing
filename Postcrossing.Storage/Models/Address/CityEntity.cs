using System.ComponentModel.DataAnnotations;

namespace Postcrossing.Storage.Models.Address;

public class CityEntity
{
    public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; }
    
    public int DistrictId { get; set; }
    public DistrictEntity Distric { get; set; }
    
    public ICollection<AddressEntity> Addresses { get; set; }
}