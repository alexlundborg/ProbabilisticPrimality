using FastEndpoints;
using JetBrains.Annotations;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

[UsedImplicitly]
public class TestWithKWitnessesEndpoint : Endpoint<TestWithKWitnessesRequest, TestWithKWitnessesResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/TestWithKWitnesses/{IntegerToTest}/{NumberOfWitnesses}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(TestWithKWitnessesRequest req, CancellationToken ct)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithKWitnesses(req.NumberOfWitnesses, req.IntegerToTest);
        
        var response = new TestWithKWitnessesResponse()
        {
            Result = testResult ? $"{req.IntegerToTest} is probably prime" : $"{req.IntegerToTest} is composite"
        };
        
        await SendAsync(response, cancellation: ct);
    }
}