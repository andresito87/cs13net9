// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, C#!");
string name = typeof(Program).Namespace ?? "<null>";
Console.WriteLine($"Namespace: {name}");
Console.WriteLine(format: "Value is {0}.", 19.8);
throw new Exception();
