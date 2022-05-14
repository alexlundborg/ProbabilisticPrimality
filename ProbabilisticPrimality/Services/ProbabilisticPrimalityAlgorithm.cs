using FluentValidation;
using FluentValidation.Results;

namespace ProbabilisticPrimality.Services;

public static class ProbabilisticPrimalityAlgorithm
{
    public static bool TestWithWitness(int witness, long integerToTest)
    {
        if (integerToTest < 2 || integerToTest % 2 == 0)
        {
            var message = $"Number to test must be an odd integer greater than 2.";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(integerToTest), message)
            });
        }
        var d = integerToTest - 1;
        while (d % 2 == 0)
        {
            d /= 2;
        }
        var e = (long) 1;
        for (var i = 0; i < d; ++i)
        {
            e = e * witness % integerToTest;
        }
        while (d != integerToTest - 1 && e != 1 && e != integerToTest - 1)
        {
            e = (e * e) % integerToTest;
            d *= 2;
        }
        return !(e != integerToTest - 1 && d % 2 == 0);
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
    
    public static bool TestWithStarWitnesses(long integerToTest)
    {
        var starWitnesses = new List<int>{2, 3};
        if (integerToTest >= 1373653)
        {
            starWitnesses.Add(5);
        }

        if (integerToTest >= 25326001)
        {
            starWitnesses.AddRange(new List<int>{7, 11});
        }

        if (integerToTest >= 2152302898747)
        {
            throw new ArgumentException("This endpoint does not support integers to test for primality over 2,152,302,898,746");
        }
        foreach (var witness in starWitnesses)
        {
            var result = TestWithWitness(witness, integerToTest);
            if (!result) return false;
        }
        return true;
    }
}