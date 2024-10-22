using System;

class Person
{
    private protected string? Name { get; set; }
    private protected string? Surname { get; set; }
    private protected int Age { get; set; }
    private protected string? PhoneNumber { get; set;}

    public Person() : this(null, null, 0, null) { }
    public Person(string? name, string? surname, int age, string? phone_number)
    {
        Name = name;
        Surname = surname;
        Age = age;
        PhoneNumber = phone_number;
    }
    public void Print()
    {
        Console.WriteLine("Info:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Surname: {Surname}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"PhoneNumber: {PhoneNumber}");
    }
    public string? GetSurname() => Surname;
}
class Student : Person
{
    private protected double Average { get; set; }
    private protected int Number_Of_Group { get; set; }

    public Student() : this(null, null, 0, null, 0, 0) { }
    public Student(string? name, string? surname, int age, string? phone_number, double average, int number_of_group) : base(name, surname, age, phone_number)
    {
        Average = average;
        Number_Of_Group = number_of_group;
    }
    new public void Print()
    {
        base.Print();
        Console.WriteLine($"Average: {Average}");
        Console.WriteLine($"Number_Of_Group: {Number_Of_Group}");
        Console.WriteLine();
    }
}

class Academy_Group
{
    public Student[] Students { get; set; }
    public int Count { get; set; }

    public Academy_Group()
    {
        Students = new Student[20];
        Count = 0;
    }

    public void Add(Student student)
    {
        if (Count < Students.Length)
        {
            Students[Count] = student;
            Count++;
        }
        else
        {
            Console.WriteLine("Can't add more students to the group");
        }
    }

    public void Remove(string surname)
    {
        bool isFound = false;
        for (int i = 0; i < Count; i++)
        {
            if (Students[i]?.GetSurname() == surname)
            {
                for (int j = i; j < Count - 1; j++)
                {
                    Students[j] = Students[j + 1];
                }
                Students[Count - 1] = null;
                Count--;
                isFound = true;
                Console.WriteLine($"\n[Student '{surname}' has been removed]\n");
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine($"\n[Student '{surname}' not found]\n");
        }
    }
    public void Edit(string surname)
    {
        bool isFound = false;
        for (int i = 0; i < Count; i++)
        {
            if (Students[i]?.GetSurname() == surname)
            {
                Console.WriteLine($"\n[Editing student '{surname}']");

                Console.Write("Enter name: ");
                string? u_name = Console.ReadLine();

                Console.Write("Enter surname: ");
                string? u_surname = Console.ReadLine();

                Console.Write("Enter age: ");
                int u_age = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter phone number: ");
                string? u_phone_number = Console.ReadLine();

                Console.Write("Enter average: ");
                double u_average = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter group number: ");
                int u_group = int.Parse(Console.ReadLine() ?? "0");

                Students[i] = new Student(u_name, u_surname, u_age, u_phone_number, u_average, u_group);
                isFound = true;

                Console.WriteLine($"\n[Student '{surname}' updated]\n");
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine($"\n[Student '{surname}' not found]\n");
        }
    }

    public void Print()
    {
        Console.WriteLine("Academy Group:");
        for (int i = 0; i < Count; i++)
        {
            Students[i]?.Print();
        }
    }
}
class MainClass
{
    public static void Main()
    {
        Academy_Group group = new Academy_Group();

        group.Add(new Student("Michael", "Jackson", 20, "0962304174", 7, 8));
        group.Add(new Student("John", "Doe", 22, "0962304974", 8, 7));
        group.Add(new Student("Anna", "Smith", 22, "0962304175", 9, 6));
        group.Print();

        group.Remove("Jackson");
        group.Print();

        group.Edit("Doe");
        group.Print();
    }
}