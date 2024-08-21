using FluentAssertions;
using Postcrossing.Domain.UseCase.CreateUser;

namespace Postcrossing.Domain.Test.CreateUser;

public class CreateUserCommandValidationShould
{
    private CreateUserCommandValidation _sut = new();

    public static IEnumerable<object[]> ReturnInValidCommand()
    {
        var valid = new CreateUserCommand("Vasya", "Pupkin",
            new CreateResidentialAddressCommand("Belarus", "Horad Minsk", "Minsk"));

        yield return [valid with { FirstName = "" }];
        yield return [valid with { LastName = "" }];
        yield return [valid with { FirstName = new string('a', 51) }];
        yield return [valid with { LastName = new string('a', 51) }];
    }

    [Theory]
    [MemberData(nameof(ReturnInValidCommand))]
    public async Task ReturnFailure_WhenCommandIsValid(CreateUserCommand command)
    {
        var actual = await _sut.ValidateAsync(command);

        actual.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task ReturnFailure_WhenCreateResidentialAddressCommandInvalid()
    {
        var validCommand = new CreateUserCommand("Vasya", "Pupkin", 
            new CreateResidentialAddressCommand("", "", ""));

        var actual = await _sut.ValidateAsync(validCommand);

        actual.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ReturnFailure_WhenCreateResidentialAddressCommandIsNull()
    {
        var validCommand = new CreateUserCommand("Vasya", "Pupkin",null);

        var actual = await _sut.ValidateAsync(validCommand);

        actual.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task ReturnSuccess_WhenCommandIsValid()
    {
        var validCommand = new CreateUserCommand("Vasya", "Pupkin",
            new CreateResidentialAddressCommand("Belarus", "Horad Minsk", "Minsk"));

        var actual = await _sut.ValidateAsync(validCommand);

        actual.IsValid.Should().BeTrue();
    }
}