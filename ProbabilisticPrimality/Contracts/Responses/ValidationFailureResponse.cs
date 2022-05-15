using JetBrains.Annotations;

namespace ProbabilisticPrimality.Contracts.Responses;

public class ValidationFailureResponse
{
    public List<string> Errors { [UsedImplicitly] get; init; } = new();
}