using FastEndpoints;
using FluentValidation;
using JetBrains.Annotations;
using ProbabilisticPrimality.Contracts.Requests;

namespace ProbabilisticPrimality.Validation;

[UsedImplicitly]
public class TestWithStarWitnessesValidator : Validator<TestWithStarWitnessesRequest>
{
    public TestWithStarWitnessesValidator()
    {
        RuleFor(x => x.IntegerToTest)
            .GreaterThan(3)
            .WithMessage("Integer to test must be greater than 3.")
            .Must(integerToTest => integerToTest % 2 != 0)
            .WithMessage("Integer to test must be odd.")
            .LessThan(2152302898747)
            .WithMessage("This endpoint does not support integers to test for primality over 2,152,302,898,746.");
    }
}