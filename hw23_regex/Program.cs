using System;
using System.Text.RegularExpressions;

namespace Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Input = {
            "(+380) 96 499 40 84",
            "380 98 499 40 84",
            "098 499 40 84",
            "098-499-40-84",
            "098-499-40-8412215"
            };
            string[] Input2 = {
            "hello123@gmail.com",
            "123@gmail.com",
            "HELO@gmail.com",
            "*mail@gmail.com",
            };

            string pattern = @"^\(?\+?380\)?[- ]?\d{2}[- ]?\d{3}[- ]?\d{2}[- ]?\d{2}$|^0\d{2}[- ]?\d{3}[- ]?\d{2}[- ]?\d{2}$";
            string pattern2 = @"^[a-z]+[a-z0-9]*@[a-z]+\.[a-z]+$";

            Regex num_regex = new Regex(pattern);
            Regex email_regex = new Regex(pattern2);

            foreach (var number in Input)
            {
                if (num_regex.IsMatch(number))
                    Console.WriteLine($"{number} is Correct");
                else
                    Console.WriteLine($"{number} is Wrong!");
            }
            foreach (var emails in Input2)
            {
                if (email_regex.IsMatch(emails))
                    Console.WriteLine($"{emails} is Correct");
                else
                    Console.WriteLine($"{emails} is Wrong!");
            }
        }
    }
}
