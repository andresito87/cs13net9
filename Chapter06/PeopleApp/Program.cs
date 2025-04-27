﻿using Packt.Shared;
Person harry = new()
{
    Name = "Harry",
    Born = new(year: 2001, month: 3, day: 25,
    hour: 0, minute: 0, second: 0,
    offset: TimeSpan.Zero)
};
harry.WriteToConsole();

// Implementing functionality using methods.
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };
// Call the instance method to marry Lamech and Adah.
lamech.Marry(adah);
// Call the static method to marry Lamech and Zillah.
// Person.Marry(lamech, zillah);
if (lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}
lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();
// Call the instance method to make a baby.
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");
// Call the static method to make a baby.
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";
// Use the * operator to "multiply".
Person baby3 = lamech * adah;
baby3.Name = "Jubal";
Person baby4 = zillah * lamech;
baby4.Name = "Naamah";
adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();
for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine(format: "  {0}'s child #{1} is named \"{2}\".",
      arg0: lamech.Name, arg1: i,
      arg2: lamech.Children[i].Name);
}

// Non-generic lookup collection.
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2; // Look up the value that has 2 as its key.
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupObject[key]);

// Look up the value that has harry as its key.
WriteLine(format: "Key {0} has value: {1}",
  arg0: harry,
  arg1: lookupObject[harry]);

// Define a generic lookup collection.
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupIntString[key]);

// Assign the method to the Shout event delegate.
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;
// Call the Poke method that eventually raises the Shout event.
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

Person?[] people =
{
  null,
  new() { Name = "Simon" },
  new() { Name = "Jenny" },
  new() { Name = "Adam" },
  new() { Name = null },
  new() { Name = "Richard" }
};
OutputPeopleNames(people, "Initial list of people:");
Array.Sort(people);
OutputPeopleNames(people,
  "After sorting using Person's IComparable implementation:");
Array.Sort(people, new PersonComparer());
OutputPeopleNames(people,
  "After sorting using PersonComparer's IComparer implementation:");

Employee john = new()
{
    Name = "John Jones",
    Born = new(year: 1990, month: 7, day: 28,
    hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero)
};
john.WriteToConsole();

john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:yyyy-MM-dd}.");

WriteLine(john.ToString());

Employee aliceInEmployee = new()
{ Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(explicitAlice)} is an Employee.");
    // Safely do something with explicitAlice.
}

Employee? aliceAsEmployee = aliceInPerson as Employee;
if (aliceAsEmployee is not null)
{
    WriteLine($"{nameof(aliceInPerson)} as an Employee.");
    // Safely do something with aliceAsEmployee.
}

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
    WriteLine(ex.Message);
}

string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: StringExtensions.IsValidEmail(email1));
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: StringExtensions.IsValidEmail(email2));

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: email1.IsValidEmail());
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: email2.IsValidEmail());

C1 c1 = new() { Name = "Bob" };
c1.Name = "Bill";
C2 c2 = new(Name: "Bob");
//c2.Name = "Bill"; // CS8852: Init-only property.
S1 s1 = new() { Name = "Bob" };
s1.Name = "Bill";
S2 s2 = new(Name: "Bob");
s2.Name = "Bill";
S3 s3 = new(Name: "Bob");
//s3.Name = "Bill"; // CS8852: Init-only property.