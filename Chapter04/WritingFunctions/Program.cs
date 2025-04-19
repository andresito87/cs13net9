// TimesTable(number: 7, size: 10);
ConfigureConsole();
decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "US");
WriteLine($"You must pay {taxToPay:C} in tax.");
ConfigureConsole("es-ES");
decimal taxToPay2 = CalculateTax(amount: 149, twoLetterRegionCode: "es");
WriteLine($"You must pay {taxToPay2:C} in tax.");
// Alternatively, call the function in the interpolated string.
// WriteLine($"You must pay {CalculateTax(amount: 149,
//   twoLetterRegionCode: "FR"):C} in tax.");


RunCardinalToOrdinal();
RunFactorial();
RunFibImperative();
RunFibFunctional();

static void RunCardinalToOrdinal()
{
    for (uint number = 1; number <= 150; number++)
    {
        Write($"{CardinalToOrdinal(number)} ");
    }
    WriteLine();
}

static void RunFactorial()
{
    for (int i = -2; i <= 15; i++)
    {
        try
        {
            WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch (OverflowException)
        {
            WriteLine($"{i}! is too big for a 32-bit integer.");
        }
        catch (Exception ex)
        {
            WriteLine($"{i}! throws {ex.GetType()}: {ex.Message}");
        }
    }
}

static void RunFibImperative()
{
    for (uint i = 1; i <= 30; i++)
    {
        WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
          arg0: CardinalToOrdinal(i),
          arg1: FibImperative(term: i));
    }
}

static int FibFunctional(uint term) => term switch
{
    0 => throw new ArgumentOutOfRangeException(),
    1 => 0,
    2 => 1,
    _ => FibFunctional(term - 1) + FibFunctional(term - 2)
};

static void RunFibFunctional()
{
    for (uint i = 1; i <= 30; i++)
    {
        WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
          arg0: CardinalToOrdinal(i),
          arg1: FibFunctional(term: i));
    }
}