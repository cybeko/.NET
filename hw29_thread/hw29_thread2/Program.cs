using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw29_thread2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randNum = random.Next(1000, 10000);

            Console.WriteLine("Press Enter when the signal goes off.");

            Console.WriteLine("Wait...");

            Thread.Sleep(randNum);

            Task.Run(() => Console.Beep());
            Console.WriteLine("Now!");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.ReadKey();

            stopwatch.Stop();

            Console.Clear();
            Console.WriteLine($"Your reaction time is {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}
