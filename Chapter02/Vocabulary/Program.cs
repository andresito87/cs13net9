// See https://aka.ms/new-console-template for more information
// #error version
//Console.WriteLine("Hello, World!");
//#region Three variables that store the number 2 million.
//int decimalNotation = 2_000_000;
//int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
//int hexadecimalNotation = 0x_001E_8480;
//#endregion

//writeline($"computer named {env.machinename} says \"no.\"");

using System.Reflection; // To use Assembly, TypeName, and so on.
// Declare some unused variables using types in
// additional assemblies to make them load too.
System.Data.DataSet ds = new();
HttpClient client = new();

// Get the assembly that is the entry point for this app.
Assembly? myApp = Assembly.GetEntryAssembly();
// If the previous line returned nothing then end the app.
if (myApp is null) return;
// Loop through the assemblies that my app references.
foreach (AssemblyName name in myApp.GetReferencedAssemblies())
{
    // Load the assembly so we can read its details.
    Assembly a = Assembly.Load(name);
    // Declare a variable to count the number of methods.
    int methodCount = 0;
    // Loop through all the types in the assembly.
    foreach (TypeInfo t in a.DefinedTypes)
    {
        // Add up the counts of all the methods.
        methodCount += t.GetMethods().Length;
    }
    // Output the count of types and their methods.
    WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.",
      arg0: a.DefinedTypes.Count(),
      arg1: methodCount,
      arg2: name.Name);
}

// Let the heightInMetres variable become equal to the value 1.88.
double heightInMetres = 1.88;
Console.WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}.");

// Outputting a emoji
Console.OutputEncoding = System.Text.Encoding.UTF8;
string grinningEmoji = char.ConvertFromUtf32(0x1F600);
Console.WriteLine(grinningEmoji);

// Interpolated Strings
var person = new { FirstName = "Alice", Age = 56 };
string json = $$"""
              {
                "first_name": "{{person.FirstName}}",
                "age": {{person.Age}},
                "calculation": "{{{1 + 2}}}"
              }
              """;
Console.WriteLine(json);