using JetBrains.Annotations;

namespace ProbabilisticPrimality.Contracts.Responses;

public class TestWithKWitnessesResponse
{
    public string Result { [UsedImplicitly] get; init; } = default!;
}