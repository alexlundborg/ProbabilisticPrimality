using FastEndpoints;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

public class TestWithWitnessEndpoint : Endpoint<TestWithWitnessRequest, TestWithWitnessResponse>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("TestWithWitness");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(TestWithWitnessRequest req, CancellationToken ct)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithWitness(req.Witness, req.IntegerToTest);
        
        var response = new TestWithWitnessResponse()
        {
            Result = testResult ? "Probably prime" : "Composite"
        };
        
        await SendAsync(response, cancellation: ct);
    }
}