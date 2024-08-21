using Postcrossing.Domain.Models;

namespace Postcrossing.Domain.UseCase.CreateUser;

public interface ICreateUserStorage
{
    public Task<User> CreateUser(string firstName, string lastName,int countyId,int districtId,int cityId,CancellationToken cancellationToken);
}