using FastEndpoints;
using ProbabilisticPrimality.Contracts.Requests;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Services;

namespace ProbabilisticPrimality.Endpoints;

public class TestWithWitnessEndpoint : Endpoint<TestWithWitnessRequest, TestWithWitnessResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/TestWithWitness/{IntegerToTest}/{Witness}");
        AllowAnonymous();
        Summary(s => {
            s.Summary = "Test primality of an integer using a specified witness number less than the integer to test";
            s.Description = "If the test result says that the integer to test is composite, " +
                            "you can be certain that it is composite. However certain witness numbers " +
                            "are liars and will incorrectly declare that an integer is prime. At most " +
                            "1/4 of witnesses are liars. if the integer to test is composite then running " +
                            "k iterations of this primality test will declare the integer to be probably prime" +
                            "with a probability at most 4 to the power of −k. Read more here: https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test#Accuracy";
        }); 
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