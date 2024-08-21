using FluentAssertions;
using Postcrossing.Domain.UseCase.CreateUser;

namespace Postcrossing.Domain.Test.CreateUser;

public class CreateResidentialAddressCommandValidationShould
{
    private readonly CreateResidentialAddressCommandValidation _sut = new();


    public static IEnumerable<object[]> ReturnInValidCommand()
    {
        var valid = new CreateResidentialAddressCommand("Belarus", "Horad Minsk", "Minsk");
        
        yield return [valid with { Country = "" }];
        yield return [valid with { District = "" }];
        yield return [valid with { City = "" }];
        yield return [valid with { Country = new string('a',51) }];
        yield return [valid with { District = new string('a',51) }];
        yield return [valid with { City = new string('a',51) }];
    }

    [Theory]
    [MemberData(nameof(ReturnInValidCommand))]
    public async Task ReturnFailure_WhenCommandIsValid(CreateResidentialAddressCommand command)
    {
        var actual = await _sut.ValidateAsync(command);

        actual.IsValid.Should().BeFalse();
    }

    [Fact]
    public async Task ReturnSuccess_WhenCommandIsValid()
    {
        var validCommand = new CreateResidentialAddressCommand("Belarus", "Horad Minsk", "Minsk");

        var actual = await _sut.ValidateAsync(validCommand);

        actual.IsValid.Should().BeTrue();
    }
}