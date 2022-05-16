using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    

    internal class Program
    {

            public class Zaehler
        {
            public void Zaehle()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Thread.Sleep(1);
                }
            }

        }

        public class MultithreadedZaehler
        {
            public void StarteZaehler()
            {
                var zaehler = new Zaehler();
                Thread thread1 = new Thread(() => zaehler.Zaehle());
                Thread thread2 = new Thread(() => zaehler.Zaehle());
                Thread thread3 = new Thread(() => zaehler.Zaehle());
                thread1.Name = "Thread1";
                thread2.Name = "Thread2";
                thread3.Name = "Thread3";

                thread1.Start();
                thread2.Start();
                thread3.Start();

                thread1.Join();
                thread2.Join();
                thread3.Join();
            }
        }

        static void Main(string[] args)
        {
            MultithreadedZaehler zaehler = new MultithreadedZaehler();
            zaehler.StarteZaehler();

            Console.ReadKey();
        }
    }

    }

