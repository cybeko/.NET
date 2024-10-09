using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw02
{
    internal class Program
    {
        static void One()
        {
            Console.Write("Введите число от 1 до 100: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 100)
            {
                Console.WriteLine("число должно быть в диапазоне от 1 до 100.");
            }
            else
            {
                if (number % 3 == 0 && number % 5 == 0)
                {
                    Console.WriteLine("Fizz Buzz");
                }
                else if (number % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (number % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
        static void Two() {
            Console.Write("Введите значение: ");
            double value = double.Parse(Console.ReadLine());

            Console.Write("Введите процент: ");
            double percentage = double.Parse(Console.ReadLine());

            double result = (value * percentage) / 100;

            Console.WriteLine($"{percentage}% от {value} = {result}");
        }
        static void Three() 
        {
            Console.Write("Цифра 1: ");
            string firstDigit = Console.ReadLine();

            Console.Write("Цифра 2: ");
            string secondDigit = Console.ReadLine();

            Console.Write("Цифра 3: ");
            string thirdDigit = Console.ReadLine();

            Console.Write("Цифра 4: ");
            string fourthDigit = Console.ReadLine();

            string combinedNumberString = firstDigit + secondDigit + thirdDigit + fourthDigit;

            int combinedNumber = int.Parse(combinedNumberString);

            Console.WriteLine($"Число: {combinedNumber}");
        }
        static void Four()
        {
            Console.Write("Введите шестизначное число: ");
            string strInput = Console.ReadLine();

            if (strInput.Length != 6)
            {
                Console.WriteLine("Ошибка: введите корректное шестизначное число.");
                return;
            }

            Console.Write("Введите число (от 1 до 6): ");
            int a = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Введите число (от 1 до 6): ");
            int b = int.Parse(Console.ReadLine()) - 1; 

            if (a < 0 || a > 5 || b < 0 || b > 5)
            {
                Console.WriteLine("Число должно быть от 1 до 6.");
                return;
            }

            char[] digits = strInput.ToCharArray();

            char temp = digits[a];
            digits[a] = digits[b];
            digits[b] = temp;

            string result = new string(digits);

            Console.WriteLine($"Результат: {result}");
        }
        static void Five()
        {
            Console.Write("Введите день (1-31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Введите месяц (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Введите год: ");
            int year = int.Parse(Console.ReadLine());

            if (day < 1 || day > 31 || month < 1 || month > 12)
            {
                Console.WriteLine("некорректная дата.");
                return;
            }

            string season;
            if (month == 12 || month <= 2)
            {
                season = "Winter";
            }
            else if (month >= 3 && month <= 5)
            {
                season = "Spring";
            }
            else if (month >= 6 && month <= 8)
            {
                season = "Summer";
            }
            else
            {
                season = "Fall";
            }
            DateTime date = new DateTime(year, month, day);
            string dayOfWeek = date.DayOfWeek.ToString();

            Console.WriteLine($"{season} {dayOfWeek}");
        }
        static void Six()
        {
            Console.Write("Введите температуру: ");
            double temp = double.Parse(Console.ReadLine());

            Console.Write("Введите 'C' или 'F: ");
            char userchoice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (userchoice == 'C' || userchoice == 'c')
            {
                double celsius = (temp - 32) * 5 / 9;
                Console.WriteLine($"{temp}°F = {celsius}°C");
            }
            else if (userchoice == 'F' || userchoice == 'f')
            {
                double fah = (temp * 9 / 5) + 32;
                Console.WriteLine($"{temp}°C = {fah}°F");
            }
        }
        static void Seven()
        {
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());

            int start = Math.Min(a, b);
            int end = Math.Max(a, b);

            Console.WriteLine($"четные числа в диапазоне от {start} до {end}:");
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
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
            Seven();
        }
    }
}
