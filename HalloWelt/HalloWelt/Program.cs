// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("What is your first name?");
string? firstName = Console.ReadLine();

Console.WriteLine("What is your last name?");
string? lastName = Console.ReadLine();

string? fullName = firstName + " " + lastName;

string greeting = $"Hello, {fullName}!";
Console.WriteLine(greeting);

for (int i = 0; i < fullName.Length; i++)
{
    Console.Write($"{fullName[i]}, ");
}
Console.WriteLine();

char[] characters = fullName.ToArray();
foreach (char c in characters)
{
    Console.Write($"{c}, ");
}
Console.WriteLine();

int counter = 0;
while (counter < fullName.Length)
{
    Console.Write($"{fullName[counter]}, ");
    counter++;
}
Console.WriteLine();

Console.WriteLine("What is your age?");
string ageAsString = Console.ReadLine();

try
{
    int age = int.Parse(ageAsString);
    int yearOfBirth = DateTime.Now.Year - age;
    Console.WriteLine($"You have been born in {yearOfBirth}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");

    return;
}