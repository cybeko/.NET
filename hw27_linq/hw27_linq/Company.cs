using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw27_linq
{
    public class Company
    {
        public DateOnly DateFounded { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Director Director { get; set; }
        public Company(DateOnly dateFounded, string name, string profile, string address, Director director, List<Employee> employees)
        {
            DateFounded = dateFounded;
            Name = name;
            Profile = profile;
            Address = address;
            Director = director;
            Employees = employees ?? new List<Employee>();
        }
        public Company(DateOnly dateFounded, string name, string profile, string address, Director director)
        {
            DateFounded = dateFounded;
            Name = name;
            Profile = profile;
            Address = address;
            Director = director;
        }
        public void ShowAllEmployees()
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees found in the company");
            }
            else
            {
                Console.WriteLine("Employees:");
                foreach (var employee in Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public override string ToString()
        {
            return $"Company: {Name}\nFounded: {DateFounded}\nProfile: {Profile}\nAddress: {Address}\nDirector: {Director}\nEmployees Count: {Employees.Count}\n";
        }
    }

}
