using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators;

internal class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address => address.Street).NotNull();
        RuleFor(address => address.City).NotNull();
        RuleFor(address => address.PostalCode).NotNull();
    }
}