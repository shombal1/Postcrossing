using System.ComponentModel.DataAnnotations;

namespace Postcrossing.Storage.Models.Address;

public class DistrictEntity
{
    public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; } = "";

    public int CountyId { get; set; }
    public CountryEntity Country { get; set; }
    
    public ICollection<CityEntity> Cities { get; set; }
    
    public ICollection<ResidentialAddressEntity> Addresses { get; set; }
}