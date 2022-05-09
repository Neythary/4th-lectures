// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

DateTime day1 = new DateTime();

DateTime day2 = new(2001, 09, 11);

var day3 = new DateTime(2001, 09, 11);


//var day4 = new DateTime
//{
//    year = 2001
//};
// -> nur getter-Methode, keine Setter

string year = "2001";
bool parsed = int.TryParse(year, out int yearParsed);

if (parsed)
{
    Console.WriteLine(yearParsed);
}
else { Console.WriteLine("ERROR!"); }