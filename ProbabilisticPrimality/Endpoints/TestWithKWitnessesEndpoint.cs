using FastEndpoints;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

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
            Result = testResult ? "Probably prime" : "Composite"
        };
        
        await SendAsync(response, cancellation: ct);
    }
}