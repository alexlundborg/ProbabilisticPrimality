using FastEndpoints;
using JetBrains.Annotations;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

[UsedImplicitly]
public class TestWithWitnessEndpoint : Endpoint<TestWithWitnessRequest, TestWithWitnessResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/TestWithWitness/{IntegerToTest}/{Witness}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(TestWithWitnessRequest req, CancellationToken ct)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithWitness(req.Witness, req.IntegerToTest);
        
        var response = new TestWithWitnessResponse()
        {
            Result = testResult ? $"{req.IntegerToTest} is probably prime" : $"{req.IntegerToTest} is composite"
        };
        
        await SendAsync(response, cancellation: ct);
    }
}