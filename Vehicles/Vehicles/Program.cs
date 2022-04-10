// See https://aka.ms/new-console-template for more information
using Vehicles;

Console.WriteLine("Hello, World!");

Auto alfa = new Auto(4);
alfa.GetAnzahlTueren();

Limosine limo = new Limosine(3);
limo.GetAnzahlTueren();

Kombi kombi = new Kombi();
kombi.GetAnzahlTueren();

Van van = new Van(false);
van.GetAnzahlTueren();