namespace Postcrossing.Domain.Models;

public class Address
{
    public string CountryName { get; set; } = "";
    public string CountryCode { get; set; } = "";
    public int CountryId { get; set; }
    public string DistrictName { get; set; } = "";
    public int DistrictId { get; set; }
    public string CityName { get; set; } = "";
    public int CityId { get; set; }
}