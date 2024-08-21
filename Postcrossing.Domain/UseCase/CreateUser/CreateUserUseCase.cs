using FluentValidation;
using Postcrossing.Domain.Models;
using Postcrossing.Domain.UseCase.GetExistLocation;

namespace Postcrossing.Domain.UseCase.CreateUser;

public class CreateUserUseCase(
    IValidator<CreateUserCommand> validator,
    IGetAddressStorage addressStorageStorage,
    ICreateUserStorage createUserStorage
) : ICreateUserUseCase
{
    public async Task<User> Execute(CreateUserCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        Address? location = await addressStorageStorage.GetAddress(
            command.AddressCommand.Country,
            command.AddressCommand.District,
            command.AddressCommand.City,
            cancellationToken);

        if (location is null)
        {
            throw new ValidationException("Address not found");
        }

        return await createUserStorage.CreateUser(command.FirstName, command.LastName, location.CountryId,
            location.DistrictId, location.CityId, cancellationToken);
    }
}