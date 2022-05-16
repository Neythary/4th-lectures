using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskProgram
{
    internal class Program
    {
        public class SimpleTaskProgram
        {
            public void Start()
            {
                Method1();
                Method2();
            }

            public async Task Method1()
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < 25; i++)
                    {
                        Console.WriteLine(" Method 1");
                        Task.Delay(100).Wait();
                    }
                });
            }

            public void Method2()
            {
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine(" Method 2");
                    Task.Delay(100).Wait();
                }
            }
        }
        static void Main(string[] args)
        {
            SimpleTaskProgram program = new SimpleTaskProgram();
            program.Start();
            Console.ReadKey();
        }
    }
}
