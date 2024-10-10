using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw03
{
    internal class Program
    {
        static void One()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 10 };

            int even = 0;
            int odd = 0;
            int unique = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }
                }
                if (count == 1)
                {
                    unique++;
                }
            }

            Console.WriteLine("Even numbers: " + even);
            Console.WriteLine("Odd numbers: " + odd);
            Console.WriteLine("Unique numbers: " + unique);
        }
        static void Two() {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 10 };

            Console.WriteLine("Enter number:");
            int userInput = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < userInput)
                {
                    count++;
                }
            }

            Console.WriteLine("Less than " + userInput + ": " + count);
        }
        static void Three()
        {
            int[] array = { 7, 6, 5, 4, 7, 6, 5, 8, 7, 6, 5 };

            Console.WriteLine("Enter num 1:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter num 2:");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter num 3:");
            int num3 = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i <= array.Length - 3; i++)
            {
                if (array[i] == num1 && array[i + 1] == num2 && array[i + 2] == num3)
                {
                    count++;
                }
            }

            Console.WriteLine($"{num1}, {num2}, {num3}: {count}");
        }
        static void Four()
        {
            Random random = new Random();

            Console.WriteLine("Enter first array length:");
            int M = int.Parse(Console.ReadLine());
            int[] array1 = new int[M];

            for (int i = 0; i < M; i++)
            {
                array1[i] = random.Next(1, 11);
            }

            Console.WriteLine("Enter second array length:");
            int N = int.Parse(Console.ReadLine());
            int[] array2 = new int[N];

            for (int i = 0; i < N; i++)
            {
                array2[i] = random.Next(1, 11);
            }

            Console.WriteLine("First arr:");
            Console.WriteLine(string.Join(", ", array1));

            Console.WriteLine("Second arr:");
            Console.WriteLine(string.Join(", ", array2));

            int[] comm_elements = new int[Math.Min(M, N)];
            int count = 0;

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (array1[i] == array2[j])
                    {
                        bool exists = false;
                        for (int k = 0; k < count; k++)
                        {
                            if (comm_elements[k] == array1[i])
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (!exists)
                        {
                            comm_elements[count] = array1[i];
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine("Common elements:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(comm_elements[i]);
            }
        }
        static void Main(string[] args)
        {
            One();
            Two();
            Three();
            Four();
        }
    }
}
