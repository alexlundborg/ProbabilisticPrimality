using FastEndpoints;
using FluentValidation;
using JetBrains.Annotations;
using ProbabilisticPrimality.Contracts.Requests;

namespace ProbabilisticPrimality.Validation;

[UsedImplicitly]
public class TestWithKWitnessesValidator : Validator<TestWithKWitnessesRequest>
{
    public TestWithKWitnessesValidator()
    {
        RuleFor(x => x.IntegerToTest)
            .GreaterThan(3)
            .WithMessage("Integer to test must be greater than 3.")
            .Must(integerToTest => integerToTest % 2 != 0)
            .WithMessage("Integer to test must be odd.");

        RuleFor(x => x.NumberOfWitnesses)
            .GreaterThan(0)
            .WithMessage("Number of witnesses must be a positive integer.")
            .LessThan(x => x.IntegerToTest)
            .WithMessage("Number of witnesses must be less than the integer to test.");
    }
}