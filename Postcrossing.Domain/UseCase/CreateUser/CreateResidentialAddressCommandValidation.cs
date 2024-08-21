using FluentValidation;

namespace Postcrossing.Domain.UseCase.CreateUser;

public class CreateResidentialAddressCommandValidation : AbstractValidator<CreateResidentialAddressCommand>
{
    public CreateResidentialAddressCommandValidation()
    {
        RuleFor(a => a.Country)
            .NotEmpty().WithErrorCode("Empty")
            .MaximumLength(50).WithErrorCode("Length too long");
        
        RuleFor(a => a.District)
            .NotEmpty().WithErrorCode("Empty")
            .MaximumLength(50).WithErrorCode("Length too long");
        
        RuleFor(a => a.City)
            .NotEmpty().WithErrorCode("Empty")
            .MaximumLength(50).WithErrorCode("Length too long");
    }
}