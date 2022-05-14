using ProbabilisticPrimality.Services;
using Xunit;

namespace ProbabilisticPrimality.Tests;

public class ProbabilisticPrimalityAlgorithmTests
{

    [Theory]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(11)]
    [InlineData(13)]
    [InlineData(17)]
    [InlineData(19)]
    [InlineData(23)]
    [InlineData(29)]
    [InlineData(31)]
    [InlineData(37)]
    [InlineData(41)]
    [InlineData(43)]
    [InlineData(47)]
    public void PrimeGreaterThanThreeAsIntegerToTestUsingTestWithStarWitnessesShouldReturnTrue(int primeNumber)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(primeNumber);
        Assert.True(testResult);
    }
}