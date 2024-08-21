using FluentAssertions;
using FluentValidation;
using Moq;
using Moq.Language.Flow;
using Postcrossing.Domain.Models;
using Postcrossing.Domain.UseCase.CreateUser;
using Postcrossing.Domain.UseCase.GetExistLocation;

namespace Postcrossing.Domain.Test.CreateUser;

public class CreateUserUseCaseShould
{
    private readonly CreateUserUseCase _sut;
    private readonly ISetup<IGetAddressStorage, Task<Address?>> _getAddressSetup;

    public CreateUserUseCaseShould()
    {
        Mock<IValidator<CreateUserCommand>> validator = new();
        Mock<ICreateUserStorage> createUserStorage = new();
        Mock<IGetAddressStorage> getAddressStorage = new();

        _getAddressSetup = getAddressStorage.Setup(s => s.GetAddress(
            It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

        createUserStorage.Setup(s => s.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(),
            It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()));

        _sut = new CreateUserUseCase(validator.Object, getAddressStorage.Object, createUserStorage.Object);
    }

    [Fact]
    public async Task ReturnValidationException_WhenAddressNotFound()
    {
        _getAddressSetup.ReturnsAsync(() => null);

        await _sut.Invoking(s =>
            s.Execute(new CreateUserCommand("", "", new CreateResidentialAddressCommand("", "", "")),
                CancellationToken.None)).Should().ThrowAsync<ValidationException>();
    }
}