using FluentValidation;
using FluentValidation.Internal;

namespace FluentValidationExample.Validators;

internal class RuleSetValidatorSelector : IValidatorSelector
{
    private readonly string[] _excludedRuleSets;

    public RuleSetValidatorSelector(string[] excludedRuleSets)
    {
        _excludedRuleSets = excludedRuleSets ?? Array.Empty<string>();
    }

    bool IValidatorSelector.CanExecute(IValidationRule rule, string propertyPath, IValidationContext context)
    {
        return rule.RuleSets == null || !rule.RuleSets.Any(ruleSet => _excludedRuleSets.Contains(ruleSet));
    }
}