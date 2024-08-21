namespace Postcrossing.Domain.UseCase.CreateUser;

public record CreateUserCommand(string FirstName,string LastName,CreateResidentialAddressCommand AddressCommand);