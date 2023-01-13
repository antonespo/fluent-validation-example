using Autofac;
using FluentValidation;
using FluentValidationExample;
using FluentValidationExample.Models;
using FluentValidationExample.Validators;

var customer = new Customer
{
    Name = "Antonio",
    Surname = "Esposito",
    Address = new Address(),
    Status = "Registered"
};

var container = AutofacConfig.Configure();
using (var scope = container.BeginLifetimeScope())
{
    //var includedRuleSets = new[] { "*" };
    //var includedRuleSets = new[] { ValidationRuleSets.BasicValidation };
    var excludedRuleSets = new[] { ValidationConstants.AddressValidation };

    //var validatorSelector = ValidatorOptions.Global.ValidatorSelectors.RulesetValidatorSelectorFactory(validationToInclude);
    var validatorSelector = new RuleSetValidatorSelector(excludedRuleSets);

    var customerValidationContext = new ValidationContext<Customer>(customer, propertyChain: null, validatorSelector);

    var validator = scope.Resolve<IValidator<Customer>>();

    var result = validator.Validate(customerValidationContext);

    Console.WriteLine($"Validation has passed: {result.IsValid}");
    Console.WriteLine("Messages: " + string.Join(", ", result.Errors.Select(error => error.ErrorMessage)));
}