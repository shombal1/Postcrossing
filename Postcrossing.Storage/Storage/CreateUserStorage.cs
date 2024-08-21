using Microsoft.EntityFrameworkCore;
using Postcrossing.Domain.Models;
using Postcrossing.Domain.UseCase.CreateUser;
using Postcrossing.Storage.Models;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Storage.Storage;

public class CreateUserStorage(PostcrossingDbContext dbContext) : ICreateUserStorage
{
    public async Task<User> CreateUser(string firstName, string lastName,int countyId,int districtId,int cityId,CancellationToken cancellationToken)
    {
        Guid userId =Guid.NewGuid();
        Guid addressId = Guid.NewGuid();
        
        UserEntity user = new UserEntity()
        {
            Id = userId,
            FirstName = firstName,
            LastName = lastName,
            ResidentialAddressId = addressId
        };
        
        var address = new ResidentialAddressEntity()
        {
            UserId = userId,
            Id = addressId,
            CountryId = countyId,
            DistrictId = districtId,
            CityId = cityId,
        };

        var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await dbContext.ResidentialAddresses.AddAsync(address, cancellationToken);
            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
        
        return await dbContext.Users.Where(u => u.Id == userId).Select(u => new User()
        {
            FirstName = firstName,
            LastName = lastName,
            UserId = userId,
            ResidentialAddress = new ResidentialAddress()
            {
                Id = u.ResidentialAddress.Id,
                Code = u.ResidentialAddress.Country.Code,
                County = u.ResidentialAddress.Country.Name,
                District = u.ResidentialAddress.District.Name,
                City = u.ResidentialAddress.City.Name
            }
        }).FirstAsync(cancellationToken);
    }
}