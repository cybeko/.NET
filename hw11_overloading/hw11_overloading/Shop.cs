using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11_overloading
{
    internal class Shop
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int Area { get; set; }

        public Shop() { }
        public Shop(string name, string description, string address, string phone_numbr, string email, int area)
        {
            Name = name;
            Description = description;
            Address = address;
            PhoneNumber = phone_numbr;
            Email = email;
            Area = area;
        }
        public void InputInfo()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();

            Console.Write("Enter description: ");
            Description = Console.ReadLine();

            Console.Write("Enter address: ");
            Address = Console.ReadLine();

            Console.Write("Enter phone number: ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Enter email: ");
            Email = Console.ReadLine();

            Console.Write("Enter area: ");
            Area = int.Parse(Console.ReadLine() ?? "0");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Info:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Phone number: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Area: {Area}");
            Console.WriteLine();
        }

        public static Shop operator +(Shop obj, int val)
        {
            Shop result = new()
            {
                Name = obj.Name,
                Description = obj.Description,
                Address = obj.Address,
                PhoneNumber = obj.PhoneNumber,
                Email = obj.Email,
                Area = obj.Area + val
            };
            return result;
        }
        public static Shop operator -(Shop obj, int val)
        {
            Shop result = new()
            {
                Name = obj.Name,
                Description = obj.Description,
                Address = obj.Address,
                PhoneNumber = obj.PhoneNumber,
                Email = obj.Email,
                Area = obj.Area - val
            };
            return result;
        }

        public static bool operator <(Shop obj1, Shop obj2)
        {
            if (obj1.Area < obj2.Area)
                return true;
            else
                return false;
        }

        public static bool operator >(Shop obj1, Shop obj2)
        {
            if (obj1.Area > obj2.Area)
                return true;
            else
                return false;
        }
        public static bool operator ==(Shop obj1, Shop obj2)
        {
            if (obj1.Area == obj2.Area)
                return true;
            else
                return false;
        }
        public static bool operator !=(Shop obj1, Shop obj2)
        {
            if (obj1.Area != obj2.Area)
                return true;
            else
                return false;
        }
    }
}
