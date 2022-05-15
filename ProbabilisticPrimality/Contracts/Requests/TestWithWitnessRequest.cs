namespace ProbabilisticPrimality.Contracts.Requests;

public class TestWithWitnessRequest
{
    public int IntegerToTest { get; init; } = default!;
    public int Witness { get; init; } = default!;
}