using Microsoft.EntityFrameworkCore;
using Postcrossing.Domain.Models;
using Postcrossing.Domain.UseCase.GetExistLocation;

namespace Postcrossing.Storage.Storage;

public class GetAddressStorage(PostcrossingDbContext dbContext) : IGetAddressStorage
{
    public async Task<Address?> GetAddress(string countryName, string districtName, string cityName,
        CancellationToken cancellationToken)
    {
        return await dbContext.Countries
            .Where(country => country.Name == countryName)
            .SelectMany(country => country.Districts.Where(district => district.Name == districtName)
                .SelectMany(district => district.Cities.Where(city => city.Name == cityName)
                    .Select(city => new Address()
                    {
                        CityId = city.Id, 
                        CityName = city.Name,
                        DistrictId = district.Id, 
                        DistrictName = district.Name,
                        CountryId = country.Id,
                        CountryName = country.Name,
                        CountryCode = country.Code
                    })))
            .FirstOrDefaultAsync(cancellationToken);
    }
}