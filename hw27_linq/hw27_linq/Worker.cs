using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw27_linq
{
    public class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Wage { get; set; }
        public string Position { get; set; }

        public Worker(string firstName, string lastName, int age, string phoneNumber, string email, int wage, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            Wage = wage;
            Position = position;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, \nAge: {Age}, \nPosition: {Position}, \nWage: {Wage}, \nContact: {PhoneNumber}, \nEmail: {Email}\n";
        }
    }

    public class Director : Worker
    {
        public Director(string firstName, string lastName, int age, string phoneNumber, string email, int wage)
            : base(firstName, lastName, age, phoneNumber, email, wage, "Director")
        {
        }

        public override string ToString()
        {
            return $"Director - {base.ToString()}";
        }
    }

    public class Employee : Worker
    {
        public Employee(string firstName, string lastName, int age, string phoneNumber, string email, int wage, string position)
            : base(firstName, lastName, age, phoneNumber, email, wage, position)
        {
        }

        public override string ToString()
        {
            return $"Employee - {base.ToString()}";
        }
    }
}
