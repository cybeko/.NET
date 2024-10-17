using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab01
{
    internal class MyMath
    {
        private string _expression;
        public string Expression
        {
            get { return _expression; }
            set {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Expression cannot be blank or conatin spaces");
                    if (!Regex.IsMatch(value, @"^[0-9\*]+$"))
                        throw new ArgumentException("Expression must only contain numbers and the '*' operator");
                    _expression = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public double CountResult()
        {
            if (string.IsNullOrEmpty(Expression))
            {
                throw new ArgumentException("Invalid expression. Cannot count result");
            }

            string[] numbers = Expression.Split('*');
            int res = 1;

            foreach (string number in numbers)
            {
                res *= int.Parse(number);
            }
            return res;
        }
        public MyMath(string expression)
        { Expression = expression; }
    }
}
