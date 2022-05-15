using FastEndpoints;
using JetBrains.Annotations;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

[UsedImplicitly]
public class TestWithStarWitnessesEndpoint : Endpoint<TestWithStarWitnessesRequest, TestWithStarWitnessesResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/TestWithStarWitnesses/{IntegerToTest}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(TestWithStarWitnessesRequest req, CancellationToken ct)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(req.IntegerToTest);
        
        var response = new TestWithStarWitnessesResponse()
        {
            Result = testResult ? $"{req.IntegerToTest} is prime" : $"{req.IntegerToTest} is composite"
        };
        
        await SendAsync(response, cancellation: ct);
    }
}