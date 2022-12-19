using FastEndpoints;
using FluentValidation;
using JetBrains.Annotations;
using ProbabilisticPrimality.Contracts.Requests;

namespace ProbabilisticPrimality.Validation;

[UsedImplicitly]
public class TestWithWitnessValidator : Validator<TestWithWitnessRequest>
{
    public TestWithWitnessValidator()
    {
        RuleFor(x => x.IntegerToTest)
            .GreaterThan(3)
            .WithMessage("Integer to test must be greater than 3.")
            .Must(integerToTest => integerToTest % 2 != 0)
            .WithMessage("Integer to test must be odd.");
        
        RuleFor(x => x.Witness)
            .GreaterThan(0)
            .WithMessage("Witness must be a positive integer.")
            .LessThan(x => x.IntegerToTest)
            .WithMessage("Witness must be less than the integer to test.");
    }            
}