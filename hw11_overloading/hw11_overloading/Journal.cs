using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw11_overloading
{
    internal class Journal
    {
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public int YearFounded { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int EmployeesCount { get; set; }

        public Journal() { }
        public Journal(string name, string description, int year_founded, string phone_numbr, string email, int employees_count)
        {
            Name = name;
            Description = description;
            YearFounded = year_founded;
            PhoneNumber = phone_numbr;
            Email = email;
            EmployeesCount = employees_count;
        }
        public void InputInfo()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();

            Console.Write("Enter description: ");
            Description = Console.ReadLine();

            Console.Write("Enter year of foundation: ");
            YearFounded = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter phone number: ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Enter email: ");
            Email = Console.ReadLine();

            Console.Write("Enter number of employees: ");
            EmployeesCount = int.Parse(Console.ReadLine() ?? "0");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Info:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Phone number: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Year of foundation: {YearFounded}");
            Console.WriteLine($"Number of employees: {EmployeesCount}");
            Console.WriteLine();
        }

        public static Journal operator +(Journal obj, int val)
        {
            Journal result = new()
            {
                Name = obj.Name,
                Description = obj.Description,
                YearFounded = obj.YearFounded,
                PhoneNumber = obj.PhoneNumber,
                Email = obj.Email,
                EmployeesCount = obj.EmployeesCount + val
            };
            return result;
        }
        public static Journal operator -(Journal obj, int val)
        {
            Journal result = new()
            {
                Name = obj.Name,
                Description = obj.Description,
                YearFounded = obj.YearFounded,
                PhoneNumber = obj.PhoneNumber,
                Email = obj.Email,
                EmployeesCount = obj.EmployeesCount - val
            };
            return result;
        }

        public static bool operator <(Journal obj1, Journal obj2)
        {
            if (obj1.EmployeesCount < obj2.EmployeesCount)
                return true;
            else
                return false;
        }

        public static bool operator >(Journal obj1, Journal obj2)
        {
            if (obj1.EmployeesCount > obj2.EmployeesCount)
                return true;
            else
                return false;
        }
        public static bool operator ==(Journal obj1, Journal obj2)
        {
            if (obj1.EmployeesCount == obj2.EmployeesCount)
                return true;
            else
                return false;
        }
        public static bool operator !=(Journal obj1, Journal obj2)
        {
            if (obj1.EmployeesCount != obj2.EmployeesCount)
                return true;
            else
                return false;
        }
    }
}
