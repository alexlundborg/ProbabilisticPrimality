namespace ProbabilisticPrimality.Services;

public static class ProbabilisticPrimalityAlgorithm
{
    public static bool TestWithWitness(int witness, long integerToTest)
    {
        var x = integerToTest - 1;
        while (x % 2 == 0)
        {
            x >>= 1;
        }
        var y = (long) 1;
        for (var i = 0; i < x; ++i)
        {
            y = y * witness % integerToTest;
        }
        while (x != integerToTest - 1 && y != 1 && y != integerToTest - 1)
        {
            y = (y * y) % integerToTest;
            x *= 2;
        }
        return !(y != integerToTest - 1 && x % 2 == 0);
    }

    public static bool TestWithKWitnesses(int k, int integerToTest)
    {
        var random = new Random();
        return Enumerable.Range(0, k)
            .Select(_ => TestWithWitness(random.Next(1, integerToTest), integerToTest))
            .All(result => result);
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

        return starWitnesses.Select(witness => TestWithWitness(witness, integerToTest)).All(result => result);
    }
}