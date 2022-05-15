namespace ProbabilisticPrimality.Contracts.Requests;

public class TestWithKWitnessesRequest
{
    public int IntegerToTest { get; init; } = default!;
    public int NumberOfWitnesses { get; init; } = default!;
}