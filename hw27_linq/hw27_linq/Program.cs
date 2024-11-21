using hw27_linq;

class Program
{
    static void WriteResults<T>(IEnumerable<T> res_1, IEnumerable<T> res_2, string description)
    {
        Console.WriteLine(description);
        foreach (var item in res_1)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        foreach (var item in res_2)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        var employees1 = new List<Employee>
        {
            new Employee("John", "Smith", 30, "0962304178", "helloworld123@gmail.com", 50000, "Manager"),
            new Employee("Alice", "Johnson", 30, "0962304179", "helloworld124@gmail.com", 70000, "Manager"),
            new Employee("Emily", "Black", 25, "0962304180", "helloworld125@gmail.com", 45000, "Developer"),
            new Employee("Lionel", "Roberts", 28, "0962304181", "helloworld126@gmail.com", 47000, "Designer")
        };

        var employees2 = new List<Employee>
        {
            new Employee("Sophia", "White", 35, "0962304182", "helloworld127@gmail.com", 60000, "Manager"),
            new Employee("James", "Brown", 40, "0962304183", "helloworld128@gmail.com", 55000, "Sales"),
            new Employee("Olivia", "Green", 32, "0962304184", "helloworld129@gmail.com", 48000, "HR")
        };

        var companies = new List<Company>
        {
            new Company(new DateOnly(2015, 5, 20), "Food Isle", "Food", "123 Baker St, London",
                new Director("Jack", "Black", 45, "0962304185", "helloworld130@gmail.com", 80000), employees1),

            new Company(new DateOnly(2010, 8, 15), "WhiteTech", "IT", "456 Elm St, London",
                new Director("Walter", "White", 50, "0962304186", "helloworld131@gmail.com", 90000), employees2),
        };


        //1
        var res_1 = from c in companies select c;
        var res_2 = companies.Select(c => c);
        WriteResults(res_1, res_2, "Получить информацию обо всех фирмах");

        res_1 = from c in companies where c.Name.Contains("Food") select c;
        res_2 = companies.Where(c => c.Name.Contains("Food"));
        WriteResults(res_1, res_2, "Получить фирмы, у которых в названии есть слово Food");

        res_1 = from c in companies where c.Profile == "Marketing" select c;
        res_2 = companies.Where(c => c.Profile == "Marketing");
        WriteResults(res_1, res_2, "Получить фирмы, которые работают в области маркетинга");

        res_1 = from c in companies where c.Profile == "Marketing" || c.Profile == "IT" select c;
        res_2 = companies.Where(c => c.Profile == "Marketing" || c.Profile == "IT");
        WriteResults(res_1, res_2, "Получить фирмы, которые работают в области маркетинга или IT");

        res_1 = from c in companies where c.Employees.Count > 100 select c;
        res_2 = companies.Where(c => c.Employees.Count > 100);
        WriteResults(res_1, res_2, "Получить фирмы с количеством сотрудников больше 100");

        res_1 = from c in companies where c.Address.Contains("London") select c;
        res_2 = companies.Where(c => c.Address.Contains("London"));
        WriteResults(res_1, res_2, "Получить фирмы, которые находятся в Лондоне");

        res_1 = from c in companies where c.Director.LastName == "White" select c;
        res_2 = companies.Where(c => c.Director.LastName == "White");
        WriteResults(res_1, res_2, "Получить фирмы, у которых фамилия директора White");

        res_1 = from c in companies
                where (DateTime.Now - c.DateFounded.ToDateTime(TimeOnly.MinValue)).TotalDays > 730
                select c;

        res_2 = companies.Where(c => (DateTime.Now - c.DateFounded.ToDateTime(TimeOnly.MinValue)).TotalDays > 730);

        WriteResults(res_1, res_2, "Получить фирмы, которые основаны больше двух лет назад");

        res_1 = from c in companies
                where (DateTime.Now - c.DateFounded.ToDateTime(TimeOnly.MinValue)).TotalDays == 123
                select c;

        res_2 = companies.Where(c => (DateTime.Now - c.DateFounded.ToDateTime(TimeOnly.MinValue)).TotalDays == 123);

        WriteResults(res_1, res_2, "Получить фирмы со дня основания, которых прошло 123 дня");

        res_1 = from c in companies where c.Director.LastName == "Black" && c.Name.Contains("White") select c;
        res_2 = companies.Where(c => c.Director.LastName == "Black" && c.Name.Contains("White"));
        WriteResults(res_1, res_2, "Получить фирмы, у которых фамилия директора Black и название фирмы содержит слово White");

        //2
        var comp_name = "Food Isle";
        var res1_1 = from c in companies
                 where c.Name == comp_name
                 from e in c.Employees
                 select e;
        var res1_2 = companies.Where(c => c.Name == comp_name).SelectMany(c => c.Employees);
        WriteResults(res1_1, res1_2, $"Получить всех конкретной фирмы {comp_name}");

        var wage = 60000;
        res1_1 = from c in companies
                 where c.Name == comp_name
                 from e in c.Employees
                 where e.Wage > wage
                 select e;
        res1_2 = companies.Where(c => c.Name == comp_name).SelectMany(c => c.Employees).Where(e => e.Wage > wage);
        WriteResults(res1_1, res1_2, $"Получить сотрудников фирмы {comp_name} с заработной платой больше {wage}");

        res1_1 = from c in companies
                 from e in c.Employees
                 where e.Position == "Manager"
                 select e;
        res1_2 = companies.SelectMany(c => c.Employees).Where(e => e.Position == "Manager");
        WriteResults(res1_1, res1_2, "Получить сотрудников всех фирм, у которых должность менеджер");

        res1_1 = from c in companies
                 from e in c.Employees
                 where e.PhoneNumber.StartsWith("23")
                 select e;
        res1_2 = companies.SelectMany(c => c.Employees).Where(e => e.PhoneNumber.StartsWith("23"));
        WriteResults(res1_1, res1_2, "Получить сотрудников, у которых телефон начинается с 23");

        res1_1 = from c in companies
                 from e in c.Employees
                 where e.Email.StartsWith("di")
                 select e;
        res1_2 = companies.SelectMany(c => c.Employees).Where(e => e.Email.StartsWith("di"));
        WriteResults(res1_1, res1_2, "Получить сотрудников, у которых Email начинается с di");

        res1_1 = from c in companies
                 from e in c.Employees
                 where e.FirstName == "Lionel"
                 select e;
        res1_2 = companies.SelectMany(c => c.Employees).Where(e => e.FirstName == "Lionel");
        WriteResults(res1_1, res1_2, "Получить сотрудников, у которых имя Lionel");
    }
}
