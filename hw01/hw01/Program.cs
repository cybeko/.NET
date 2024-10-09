using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw01
{
    internal class Program
    {
        static void One()
        {
            string str = "It's easy\r\nto win forgiveness for being wrong; being right is what gets you\r\ninto real trouble.\r\nBjarne Stroustrup";
            Console.WriteLine(str);
        }
        static void Two()
        {
            int sum = 0;
            int product = 1;
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Введите число {i}: ");
                int number = int.Parse(Console.ReadLine());

                sum += number;

                product *= number;

                if (number > max)
                    max = number;

                if (number < min)
                    min = number;
            }

            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Максимум: {max}");
            Console.WriteLine($"Минимум: {min}");
        }
        static void Three()
        {
            Console.Write("Введите шестизначное число: ");
            string str_input = Console.ReadLine();

            if (str_input.Length != 6)
            {
                Console.WriteLine("Введите корректное шестизначное число.");
            }
            else
            {
                int input = Convert.ToInt32(str_input);
                int reversed = 0;
                Console.WriteLine(input);

                while (input > 0)
                {
                    int lastDigit = input % 10;
                    reversed = (reversed * 10) + lastDigit;
                    input /= 10;
                }
                Console.WriteLine(reversed);
            }
        }
        static void Four()
        {
            Console.WriteLine("Enter min: ");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter max: ");
            int max = int.Parse(Console.ReadLine());

            int a = 0;
            int b = 1;

            if (min > max)
            {
                Console.WriteLine("Error");
            }
            else
            {
                while (a <= max)
                {
                    if (a >= min)
                    {
                        Console.WriteLine(a);
                    }

                    int next = a + b;
                    a = b;
                    b = next;
                }
            }
        }
        static void Five()
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
        static void Six()
        {
            Console.Write("Введите длину линии: ");
            int length = int.Parse(Console.ReadLine());

            Console.Write("Введите символ заполнителя: ");
            string symbol = Console.ReadLine();
            if (symbol.Length != 1)
            {
                Console.WriteLine("Введите только один символ.");
                return;
            }

            Console.Write("Введите направление линии (h/v): ");
            string direction = Console.ReadLine().ToLower();

            if (direction != "h" && direction != "v")
            {
                Console.WriteLine("Введите корректное направление линии).");
                return;
            }

            if (direction == "h")
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            else if (direction == "v")
            {
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(symbol);
                }
            }

        }
        static void Main(string[] args)
        {
            One();
            Two();
            Three();
            Four();
            Five();
            Six();
        }
    }
}
