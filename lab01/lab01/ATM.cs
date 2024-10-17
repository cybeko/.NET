using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    internal class ATM
    {
        private string _card_number;
        private string _name;
        private string _last_name;
        private string _cvc;
        private DateOnly _expiration_date;

        public string CardNumber { 
            get { return _card_number; } 
            set {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Card number cannot be blank or conatin spaces");

                    if (value.Length != 16)
                        throw new ArgumentException("Card number must contain 16 digits");

                    if (!value.All(char.IsDigit))
                        throw new ArgumentException("Card number must contain only digits");

                    _card_number = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } 
        }
        public string Name
        {
            get { return _name; }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Name number cannot be blank or conatin spaces");
                    if (!value.All(char.IsLetter))
                        throw new ArgumentException("Name must contain only letters");

                    _name = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public string LastName
        {
            get { return _last_name; }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("last name cannot be blank or conatin spaces");
                    if (!value.All(char.IsLetter))
                        throw new ArgumentException("Last name must contain only letters");
                    _last_name = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public string Cvc
        {
            get { return _cvc; }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("CVC cannot be blank or conatin spaces");

                    if (value.Length != 3)
                        throw new ArgumentException("CVC must contain 3 digits");

                    if (!value.All(char.IsDigit))
                        throw new ArgumentException("CVC must contain only digits");

                    _cvc = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public DateOnly ExpirationDate
        {
            get { return _expiration_date; }
            set
            {
                try
                {
                    if (value < DateOnly.FromDateTime(DateTime.Now))
                        throw new ArgumentException("Expiration date must be a future date.");

                    _expiration_date = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public ATM () { }

        public ATM(string cardNumber, string name, string lastName, string cvc, DateOnly expirationDate)
        {
            CardNumber = cardNumber;
            Name = name;
            LastName = lastName;
            Cvc = cvc;
            ExpirationDate = expirationDate;
        }
        public void InputCardDetails()
        {
            Console.Write("Enter Card Number: ");
            CardNumber = Console.ReadLine();

            Console.Write("Enter Full Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter Full Name: ");
            LastName = Console.ReadLine();

            Console.Write("Enter CVC: ");
            Cvc = Console.ReadLine();

            Console.Write("Enter Expiration Date (yyyy.mm.dd): ");
            ExpirationDate = DateOnly.Parse(Console.ReadLine());
        }
    }
}
