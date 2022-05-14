using FastEndpoints;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

public class TestWithStarWitnessesEndpoint : Endpoint<TestWithStarWitnessesRequest, TestWithStarWitnessesResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/TestWithStarWitnesses/{IntegerToTest}");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "Test primality of an integer using star witnesses";
            s.Description = "Star witnesses never lie. For integers to test up to 1373653, 2 and 3 are star witnesses." +
                            "For numbers up to 25326001, 5 is added. For greater numbers, 7 and 11 are added. " +
                            "Note that testing primality for larger numbers take longer time. " +
                            "Read more here: https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test#Miller_test";
            s.Response<TestWithStarWitnessesResponse>(200, "Test was successful");
            s.Response<ValidationFailureResponse>(400, "The request did not pass validation");        }); 
    }
    
    public override async Task HandleAsync(TestWithStarWitnessesRequest req, CancellationToken ct)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(req.IntegerToTest);
        
        var response = new TestWithStarWitnessesResponse()
        {
            Result = testResult ? "Prime" : "Composite"
        };
        
        await SendAsync(response, cancellation: ct);
    }
}