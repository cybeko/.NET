using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw29_thread
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Thread thread = new Thread(new ParameterizedThreadStart(NumbersToString));
            thread.Start(numbers);
        }
        static void NumbersToString(object obj)
        {
            if (obj is List<int> numbers)
            {
                foreach (var i in numbers)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}
