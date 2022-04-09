// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("Write two Numbers!");

string? numberOne = Console.ReadLine();
string? numberTwo = Console.ReadLine();

try
{
    int onee = int.Parse(numberOne);
    int twoo = int.Parse(numberTwo);
    Console.WriteLine($"Your numbers are {onee} and {twoo}.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
    return;
}

float one = float.Parse(numberOne);
float two = float.Parse(numberTwo);

float add = one + two;
float sub = one - two;
float mul = one * two;
float div = one / two;

Console.WriteLine($"Addition: {add}, Subtraction: {sub}, Multiplication: {mul}, Division: {div}.");

//zahl 2 auf 0 prüfen, um Fehler bei der Division zu vermeiden
//mehrere Try-Catch-Blöcke, auch nach den einzelnen Berechnungen -> Vorsicht Variablen sind dann je Block begrenzt