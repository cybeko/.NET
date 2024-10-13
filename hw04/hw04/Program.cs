using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw04
{
    internal class Program
    {
        static void Task1()
        {
            Random rand = new Random();

            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 6);
            }

            Console.WriteLine("Original array: " + string.Join(", ", arr));

            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[index++] = arr[i];
                }
            }

            for (int i = index; i < arr.Length; i++)
            {
                arr[i] = -1;
            }

            Console.WriteLine("Final array: " + string.Join(", ", arr));
        }
        static void Task2()
        {
            Console.Write("Enter size of the matrix: ");
            int N = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];

            int x = N / 2;
            int y = N / 2;

            matrix[x, y] = 1;
            int value = 2;

            int[,] directions = { 
                { 0, -1 }, 
                { -1, 0 }, 
                { 0, 1 }, 
                { 1, 0 } 
            };

            int steps = 1;
            int curDir = 0;

            while (value <= N * N)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < steps; j++)
                    {
                        x += directions[curDir, 0];
                        y += directions[curDir, 1];

                        if (x >= 0 && x < N && y >= 0 && y < N)
                        {
                            matrix[x, y] = value++;
                        }
                    }
                    curDir = (curDir + 1) % 4;
                }
                steps++;
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] < 10)
                    {
                        Console.Write(" " + matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Task3()
        {
            Console.Write("Enter number of rows: ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Enter number of columns: ");
            int M = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, M];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = random.Next(0, 101);
                }
            }

            Console.WriteLine("Original matrix:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }

            Console.Write("Enter number of columns to shift: ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Enter shift direction (r or l): ");
            string dir = Console.ReadLine().ToLower();

            shift = shift % M;

            for (int i = 0; i < N; i++)
            {
                int[] row = new int[M];

                if (dir == "r")
                {
                    for (int j = 0; j < M; j++)
                    {
                        row[(j + shift) % M] = matrix[i, j];
                    }
                }
                else if (dir == "l")
                {
                    for (int j = 0; j < M; j++)
                    {
                        row[j] = matrix[i, (j + shift) % M];
                    }
                }
                else
                {
                    Console.WriteLine("Invalid direction");
                    return;
                }

                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            Console.WriteLine("Shifted matrix:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
    }
}
