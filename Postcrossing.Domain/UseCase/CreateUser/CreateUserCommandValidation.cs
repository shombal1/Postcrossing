using FluentValidation;
using FluentValidation.Validators;

namespace Postcrossing.Domain.UseCase.CreateUser;

public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidation()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithErrorCode("Empty")
            .MaximumLength(50).WithErrorCode("Length too long");

        RuleFor(c => c.LastName)
            .NotEmpty().WithErrorCode("Empty")
            .MaximumLength(50).WithErrorCode("Length too long");

        RuleFor(c => c.AddressCommand)
            .SetValidator(new CreateResidentialAddressCommandValidation())
            .NotNull().WithErrorCode("Null");
    }
}