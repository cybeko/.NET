using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class ArrayManager
    {
        public delegate int[] ArrayDelegate(int[] array);

        public static int[] GetEvenNumbers(int[] array)
        {
            List<int> result = new List<int>();
            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }

        public static int[] GetOddNumbers(int[] array)
        {
            List<int> result = new List<int>();
            foreach (int number in array)
            {
                if (number % 2 != 0)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }

        public static int[] GetPrimeNumbers(int[] array)
        {
            List<int> primeNumbers = new List<int>();
            foreach (int number in array)
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            }
            return primeNumbers.ToArray();
        }

        public static int[] GetFibonacciNumbers(int[] array)
        {
            List<int> fibonacciNumbers = new List<int>();
            int a = 1;
            int b = 1;

            if (array.Contains(a))
            {
                fibonacciNumbers.Add(a);
            }

            while (b <= array.Max())
            {
                if (array.Contains(b) && b != a)
                {
                    fibonacciNumbers.Add(b);
                }

                int next = a + b;
                a = b;
                b = next;
            }
            return fibonacciNumbers.ToArray();
        }


        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }
    }
}