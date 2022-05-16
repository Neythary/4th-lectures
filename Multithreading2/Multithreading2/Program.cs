using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading2
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Multithreading2 multithreading2 = new Multithreading2();
            multithreading2.Start();
            Console.ReadLine();
        }
    }

    public class Multithreading2
    {


        private static string Arbeite(string name)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{name}: {i}");
                Task.Delay(1).Wait();
            }
            return "erledigt";
        }

        public async void Start()
        {
            string ergebnis = await Funktion1();
            Funktion2(ergebnis);
            Funktion3();
        }

        public async Task<string> Funktion1()
        {
            Task<string> aufgabe = Task.Run(() => Arbeite("task1"));
            await aufgabe;
            return aufgabe.Result;
        }

        public async Task<string> Funktion2(string ergebnis)
        {
            Task<string> aufgabe = Task.Run(() => Arbeite("task2"));
            await aufgabe;
            return aufgabe.Result;
        }

        public async Task<string> Funktion3()
        {
            Task<string> aufgabe = Task.Run(() => Arbeite("task3"));
            await aufgabe;
            return aufgabe.Result;
        }
    }
}
