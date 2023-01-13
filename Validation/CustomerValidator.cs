using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator(IValidator<Address> addressValidator)
    {
        RuleSet(ValidationConstants.BasicValidation, () =>
        {
            RuleFor(customer => customer.Name).NotNull();
            RuleFor(customer => customer.Surname).NotNull();
        });

        RuleFor(customer => customer.Status).NotNull();

        RuleSet(ValidationConstants.AddressValidation, () =>
        {
            RuleFor(customer => customer.Address)
                .NotEmpty()
                .DependentRules(() => RuleFor(x => x.Address).SetValidator(addressValidator));
        });
    }
}