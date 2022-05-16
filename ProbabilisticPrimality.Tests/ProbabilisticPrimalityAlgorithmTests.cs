using FluentValidation;
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
    [InlineData(53)]
    [InlineData(59)]
    [InlineData(61)]
    [InlineData(67)]
    [InlineData(71)]
    [InlineData(73)]
    [InlineData(79)]
    [InlineData(83)]
    [InlineData(89)]
    [InlineData(97)]
    public void First100PrimesGreaterThanThreeAsIntegerToTestUsingTestWithStarWitnessesShouldReturnTrue(int primeNumber)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(primeNumber);
        Assert.True(testResult);
    }
    
    [Theory]
    [InlineData(9)]
    [InlineData(15)]
    [InlineData(21)]
    [InlineData(25)]
    [InlineData(27)]
    [InlineData(33)]
    [InlineData(35)]
    [InlineData(39)]
    [InlineData(45)]
    [InlineData(49)]
    [InlineData(51)]
    [InlineData(55)]
    [InlineData(57)]
    [InlineData(63)]
    [InlineData(65)]
    [InlineData(69)]
    [InlineData(75)]
    [InlineData(77)]
    [InlineData(81)]
    [InlineData(85)]
    [InlineData(87)]
    [InlineData(91)]
    [InlineData(93)]
    [InlineData(95)]
    [InlineData(99)]
    public void First100OddCompositeNumbersAsIntegerToTestUsingTestWithStarWitnessesShouldReturnFalse(int compositeNumber)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(compositeNumber);
        Assert.False(testResult);
    }
    
    [Theory]
    [InlineData(2, 2047)]
    [InlineData(2, 3277)]
    [InlineData(2, 4033)]
    [InlineData(2, 4681)]
    [InlineData(2, 8321)]
    [InlineData(3, 121)]
    [InlineData(3, 703)]
    [InlineData(3, 1891)]
    [InlineData(3, 3281)]
    [InlineData(3, 8401)]
    [InlineData(5, 781)]
    [InlineData(5, 1541)]
    [InlineData(5, 5461)]
    [InlineData(5, 5611)]
    [InlineData(5, 7813)]
    public void PseudoPrimesAsIntegerToTestAndLiarsAsWitnessUsingTestWithWitnessShouldReturnFalse(int liar, int pseudoPrime)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithWitness(liar, pseudoPrime);
        Assert.True(testResult);
    }
    
    [Theory]
    [InlineData(10, 11)]
    [InlineData(10, 111)]
    [InlineData(10, 1111)]
    public void ValidIntegerAsIntegerToTestAndValidNumberOfWitnessesAndAsKUsingTestWithKWitnessesShouldReturnBool(int k, int integerToTest)
    {
        var testResult = ProbabilisticPrimalityAlgorithm.TestWithKWitnesses(k, integerToTest);
        Assert.IsType<bool>(testResult);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void IntegersLessThan4AsIntegerToTestUsingTestWithStarWitnessesShouldThrowValidationException(int invalidInteger)
    {
        Assert.Throws<ValidationException>(() => ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(invalidInteger));
    }
    
    [Theory]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(8)]
    public void EvenIntegerAsIntegerToTestUsingTestWithStarWitnessesShouldThrowValidationException(int invalidInteger)
    {
        Assert.Throws<ValidationException>(() => ProbabilisticPrimalityAlgorithm.TestWithStarWitnesses(invalidInteger));
    }
}