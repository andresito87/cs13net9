string password = "ninja";
if (password.Length < 8)
{
    WriteLine("Your password is too short. Use at least 8 chars.");
}
else
{
    WriteLine("Your password is strong.");
}

// Add and remove the "" to change between string and int.
object o = "3";
int j = 4;
if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}

// Inclusive lower bound but exclusive upper bound.
int number = Random.Shared.Next(minValue: 1, maxValue: 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // Jumps to end of switch statement.
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3: // Multiple case section.
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
} // End of switch statement.
WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");

var animals = new Animal?[]
{
  new Cat { Name = "Karen", Born = new(year: 2022, month: 8,
    day: 23), Legs = 4, IsDomestic = true },
  null,
  new Cat { Name = "Mufasa", Born = new(year: 1994, month: 6,
    day: 12) },
  new Spider { Name = "Sid Vicious", Born = DateTime.Today,
    IsVenomous = true},
  new Spider { Name = "Captain Furry", Born = DateTime.Today }
};
foreach (Animal? animal in animals)
{
    string message = animal switch
    {
        Cat fourLeggedCat when fourLeggedCat.Legs == 4 => $"The cat named {fourLeggedCat.Name} has four legs.",
        Cat wildCat when wildCat.IsDomestic == false => $"The non-domestic cat is named {wildCat.Name}.",
        Cat cat => $"The cat is named {cat.Name}.",
        Spider spider when spider.IsVenomous => $"The {spider.Name} spider is venomous. Run!",
        null => "The animal is null.",
        // default is always evaluated last.
        _ => $"{animal.Name} is a {animal.GetType().Name}.",
    };
    WriteLine($"switch statement: {message}");
}