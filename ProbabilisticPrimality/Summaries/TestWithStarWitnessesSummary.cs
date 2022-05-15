using FastEndpoints;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Endpoints;

namespace ProbabilisticPrimality.Summaries;

public class TestWithStarWitnessesSummary : Summary<TestWithStarWitnessesEndpoint>
{
    public TestWithStarWitnessesSummary()
    {
        Summary = "Test primality of an integer using star witnesses";
        Description = "Star witnesses never lie. For integers to test up to 1373653, 2 and 3 are star witnesses. For numbers up to 25326001, 5 is added. For greater numbers, 7 and 11 are added. Note that testing primality for larger numbers takes longer time. Read more here: https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test#Miller_test";
        Response<TestWithKWitnessesResponse>(200, "Test was successful");
        Response<ValidationFailureResponse>(400, "The request did not pass validation");
    }
}
