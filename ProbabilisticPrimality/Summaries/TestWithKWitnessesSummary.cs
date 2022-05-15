using FastEndpoints;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Endpoints;

namespace ProbabilisticPrimality.Summaries;

public class TestWithKWitnessesSummary : Summary<TestWithKWitnessesEndpoint>
{
    public TestWithKWitnessesSummary()
    {
        Summary = "Test primality of an integer using a specified number of randomly selected witness numbers less than the integer to test";
        Description = "If the test result says that the integer to test is composite, you can be sure that it is composite. However, certain witness numbers are liars and will incorrectly declare that an integer is prime. At most 1/4 of witnesses are liars. if the integer to test is composite then running k iterations of this primality test will declare the integer to be probably prime with a probability at most 4 to the power of −k. Read more here: https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test#Accuracy";
        Response<TestWithKWitnessesResponse>(200, "Test was successful");
        Response<ValidationFailureResponse>(400, "The request did not pass validation");
    }
}
