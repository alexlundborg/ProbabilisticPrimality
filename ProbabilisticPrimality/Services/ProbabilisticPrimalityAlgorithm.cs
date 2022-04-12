namespace ProbabilisticPrimality.Services;

public static class ProbabilisticPrimalityAlgorithm
{
    public static bool TestWithWitness(int witness, int integerToTest)
    {
        if (integerToTest < 2 || integerToTest % 2 == 0) throw new ArgumentException("The integer to test for primality must be odd and greater than 2.");
        var d = integerToTest - 1;
        while (d % 2 == 0)
        {
            d /= 2;
        }
        var intermediateResult = (long) 1;
        for (var i = 0; i < d; ++i)
        {
            intermediateResult = intermediateResult * witness % integerToTest;
        }
        while (d != integerToTest - 1 && intermediateResult != 1 && intermediateResult != integerToTest - 1)
        {
            intermediateResult = (intermediateResult * intermediateResult) % integerToTest;
            d *= 2;
        }
        return !(intermediateResult != integerToTest - 1 && d % 2 == 0);
    }

    public static bool TestWithKWitnesses(int k, int integerToTest)
    {
        var random = new Random();
        for (var i = 0; i < k; i++)
        {
            var result = TestWithWitness(random.Next(integerToTest - 1) + 1, integerToTest);
            if (!result) return false;
        }
        return true;
    }
}