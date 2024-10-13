using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw05
{
    internal class Program
    {
        static void Task1()
        {
            Console.Write("Enter string: ");
            string input = Console.ReadLine();

            Console.Write("Enter shift (0-25): ");
            int shift;
            while (!int.TryParse(Console.ReadLine(), out shift) || shift < 0 || shift > 25)
            {
                Console.Write("Incorrect input. ");
            }

            StringBuilder result = new StringBuilder();
            Console.WriteLine("1 - cipher, 2 - decipher: ");
            int action;
            while (!int.TryParse(Console.ReadLine(), out action) || (action != 1 && action != 2))
            {
                Console.Write("Incorrect input.");
            }

            if (action == 2)
            {
                shift = 26 - (shift % 26);
            }

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char transformedChar = (char)((((c - baseChar) + shift) % 26) + baseChar);
                    result.Append(transformedChar);
                }
                else
                {
                    result.Append(c);
                }
            }

            if (action == 1)
            {
                Console.WriteLine($"Ciphered: {result.ToString()}");
            }
            else
            {
                Console.WriteLine($"Deciphered: {result.ToString()}");
            }

        }
        static void Task2()
        {
            Console.WriteLine("Enter a math equation:");
            string input = Console.ReadLine();

            input = input.Replace(" ", "");

            double result = 0;
            double currentNumber = 0;
            char operation = '+';

            StringBuilder expression = new StringBuilder(input);
            string[] tokens = expression.ToString().Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out currentNumber))
                {
                    switch (operation)
                    {
                        case '+':
                            result += currentNumber;
                            break;
                        case '-':
                            result -= currentNumber;
                            break;
                    }
                }
                else {
                    throw new FormatException($"Wrong symbol: '{token}'");
                }

                if (input.Length > 0)
                {
                    if (input[0] == '+' || input[0] == '-')
                    {
                        operation = input[0];
                        input = input.Substring(1);
                    }
                }
            }
            Console.WriteLine($"Result: {result}");
            
        }
        static void Task3( )
        {
            Console.WriteLine("Enter text:");
            string inp = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            bool capNext = true;
            for (int i = 0; i < inp.Length; i++)
            {
                char curChar = inp[i];

                if (curChar == '.' || curChar == '!' || curChar == '?')
                {
                    result.Append(curChar);
                    capNext = true;
                }
                else if (char.IsWhiteSpace(curChar))
                {
                    result.Append(curChar);
                }
                else
                {
                    if (capNext && char.IsLetter(curChar))
                    {
                        result.Append(char.ToUpper(curChar));
                        capNext = false;
                    }
                    else
                    {
                        result.Append(curChar);
                    }
                }
            }
            Console.WriteLine("Result:");
            Console.WriteLine(result.ToString());
        }
        static void Task4( ) 
        {

            string inputText, forbiddenWord;
            int replCount = 0;

            Console.WriteLine("Enter text:");
            inputText = Console.ReadLine();

            Console.WriteLine("Enter forbidden word:");
            forbiddenWord = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            string replacedWord = new string('*', forbiddenWord.Length); 

            string[] words = inputText.Split(new[] { ' ', '\n', '\r', '.', ',', '!', '?', ';', ':', '\'', '\"' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (word.ToLower() == forbiddenWord.ToLower())
                {
                    result.Append(replacedWord);
                    replCount++;
                }
                else
                {
                    result.Append(word);
                }
                result.Append(" ");
            }
            Console.WriteLine("Result:");
            Console.WriteLine(result.ToString().TrimEnd());
            Console.WriteLine($"{replCount} '{forbiddenWord}' replaced.");
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();


        }
    }
}
