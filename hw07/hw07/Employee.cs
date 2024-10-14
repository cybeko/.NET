using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw07
{
    internal class Employee
    {
        private string _name;
        private int _age;
        private StringBuilder _phone_number = new StringBuilder();
        private StringBuilder _email = new StringBuilder();
        private StringBuilder _job_title = new StringBuilder();
        private DateOnly _dob;
        private string[] _duties;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string PhoneNumber {
            get { return _phone_number.ToString(); }
            set
            {
                _phone_number.Clear();
                _phone_number.Append(value);
            }
        }

        public string Email
        {
            get { return _email.ToString(); }
            set
            {
                _email.Clear();
                _email.Append(value);
            }
        }

        public string JobTitle
        {
            get { return _job_title.ToString(); }
            set
            {
                _job_title.Clear();
                _job_title.Append(value);
            }
        }

        public DateOnly Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public string[] Duties
        {
            get { return _duties; }
            set { _duties = value; }
        }
        public Employee()
        {
            _name = "Unknown";
            _age = 0;
            _phone_number.Clear();
            _email.Clear(); 
            _job_title.Clear();
            _dob = DateOnly.MinValue;
            _duties = Array.Empty<string>();
        }
        public Employee(string name, int age, string phoneNumber, string email, string jobTitle, DateOnly dob, string[] duties)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            JobTitle = jobTitle;
            Dob = dob;
            Duties = duties;
        }
        public void InputData()
        {
            Console.Write("Enter Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Phone Number: ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            Email = Console.ReadLine();

            Console.Write("Enter Job Title: ");
            JobTitle = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy.mm.dd): ");
            Dob = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter Duties (comma-separated): ");
            Duties = Console.ReadLine().Split(',');
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Employee Information:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Job title: {JobTitle}");
            Console.WriteLine($"Date of Birth: {Dob}");

            if (Duties != null && Duties.Length > 0)
            {
                Console.WriteLine("Duties:");
                for (int i = 0; i < Duties.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Duties[i]}");
                }
            }
            else
            {
                Console.WriteLine("Duties: no duties");
            }

            Console.WriteLine();
        }
    }
}
