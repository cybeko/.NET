using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw08
{
    internal class Airplane
    {
        private StringBuilder _manufacturer = new StringBuilder();
        private StringBuilder _type = new StringBuilder();

        public string Name { get; set; }
        public int Year { get; set; }

        public string Manufacturer
        {
            get { return _manufacturer.ToString(); }
            set
            {
                _manufacturer.Clear();
                _manufacturer.Append(value);
            }
        }

        public string Type
        {
            get { return _type.ToString(); }
            set
            {
                _type.Clear();
                _type.Append(value);
            }
        }

        public Airplane()
        {
        }
        public Airplane(string name, string manufacturer, string type, int year)
        {
            Name = name;
            Manufacturer = manufacturer;
            Type = type;
            Year = year;
        }
        public void InputData()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter manufacturer: ");
            Manufacturer = Console.ReadLine();
            Console.Write("Enter yype: ");
            Type = Console.ReadLine();
            Console.Write("Enter year of manufacture: ");
            Year = int.Parse(Console.ReadLine() ?? "0");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Airplane info:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine();
        }
    }
}
