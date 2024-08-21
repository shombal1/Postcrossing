using Postcrossing.Domain.Models;

namespace Postcrossing.Domain.UseCase.GetExistLocation;

public interface IGetAddressStorage
{
    public Task<Address?> GetAddress(string countryName, string districtName, string cityName,CancellationToken cancellationToken);
}