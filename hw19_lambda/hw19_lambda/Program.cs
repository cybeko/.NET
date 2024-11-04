using hw19_lambda;
using System;
using System.IO;
using System.Text;
using System.Threading;


namespace AnonymousMethods
{
    class Program
    {
        public delegate void GetRGB(string color);
        public delegate int CountArrayNumbers(int[] arr); 
        public delegate int CountPositiveNumbers(int[] arr);
        public delegate void GetUniqueNeg(int[] arr);
        public delegate bool GetWord(string str, string word);
        static void Main(string[] args)
        {
            int[] numbers = { -1, -1, 3, -9, -2, 1, 7, 14, 21, 28, 3, 10, 42, 50, 56, 63 };

            #region task 1
            GetRGB getRGB = delegate (string color)
            {
                int r, g, b;
                switch (color.ToLower())
                {
                    case "red": (r, g, b) = (255, 0, 0); break;
                    case "orange": (r, g, b) = (255, 165, 0); break;
                    case "yellow": (r, g, b) = (255, 255, 0); break;
                    case "green": (r, g, b) = (0, 255, 0); break;
                    case "blue": (r, g, b) = (0, 0, 255); break;
                    case "purple": (r, g, b) = (128, 0, 128); break;
                    default:
                        Console.WriteLine("Color not found");
                        return;
                }

                Console.WriteLine($"Color: {color}, RGB: ({r}, {g}, {b})");
            };
            Console.WriteLine("Enter color:");
            string? inputColor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputColor)) getRGB(inputColor);
            else Console.WriteLine("Empry field");
            #endregion

            #region task 2
            List<BackpackObject> items1 =
            [
                new("Bottle", 1, 1),
                new("Notebook", 5, 1),
                new("Pen", 3, 2),
                new("Chapstick", 5, 5)
            ];
            Backpack backpack = new Backpack("Black", "Kanken", "Nylon", 1.5, 15, items1);
            backpack.OutputInfo();

            BackpackObject item = new BackpackObject("Apple", 0.3, 0.5);

            backpack.AddObject(item);
            backpack.OutputInfo();

            List<BackpackObject> items2 =
            [
                new("Book", 1, 1),
                new("Wallet", 5, 1),
            ];
            backpack.AddObject(items2);
            backpack.OutputInfo();

            #endregion

            #region task 3

            CountArrayNumbers countMultiples = delegate (int[] arr)
            {
                int count = 0;
                foreach (int num in arr)
                {
                    if (num % 7 == 0)
                    {
                        count++;
                    }
                }
                return count;
            };

            int count = countMultiples(numbers);
            Console.WriteLine($"amount of numbers divisible by 7: {count}");
            #endregion

            #region 4
            CountPositiveNumbers countPosNumbers = delegate (int[] arr)
            {
                int count = 0;
                foreach (int num in arr)
                {
                    if (num > 0)
                    {
                        count++;
                    }
                }
                return count;
            };

            int posCount = countPosNumbers(numbers);
            Console.WriteLine($"amount of positive numbers: {posCount}");
            #endregion

            #region 5
            GetUniqueNeg getUniqueNeg = arr =>
            {
                var uniqueNegatives = arr.Where(num => num < 0).Distinct();
                Console.WriteLine("Distinct negative numbers:");
                foreach (var num in uniqueNegatives)
                    Console.WriteLine(num);
            };

            getUniqueNeg(numbers);
            #endregion

            #region 6
            string text = "Hello world";
            string word = "World";

            GetWord containsWord = (text, word) => text.Contains(word.ToLower());
            bool result = containsWord(text, word);
            Console.WriteLine($"Word: {result}");
            #endregion
        }
    }
}
