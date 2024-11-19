using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public int Age { get; set; }
    public string LastName { get; set; }
    public string University { get; set; }

    public Student()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        University = string.Empty;
    }
    public Student(string firstName, string lastName, int age, string university)
    {
        FirstName = firstName;
        LastName = lastName;
        University = university;
        Age = age;
    }
    public override string ToString()
    {
        return $"Student: {FirstName} {LastName}, Age: {Age}, University: {University}";
    }
}
class Program
{
    static void WriteResults<T>(IEnumerable<T> res1, IEnumerable<T> res2, string description)
    {
        Console.WriteLine(description);
        foreach (var item in res1)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        foreach (var item in res2)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        //1
        int[] arr = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88, 49, -1, 5, -8, 100 };

        var task_1 = from i in arr select i;
        var task_2 = arr.Select(i => i);
        WriteResults(task_1, task_2, "Получить весь массив целых");

        task_1 = from i in arr where i % 2 == 0 select i;
        task_2 = arr.Where(i => i % 2 == 0);
        WriteResults(task_1, task_2, "Получить четные целые");

        task_1 = from i in arr where i < 0 select i;
        task_2 = arr.Where(i => i < 0);
        WriteResults(task_1, task_2, "Получить отрицательные числа");

        int num = 5;
        task_1 = from i in arr where i > num select i;
        task_2 = arr.Where(i => i > num);
        WriteResults(task_1, task_2, "Получить значения больше заданного");

        int min = 5, max = 60;
        task_1 = from i in arr where i > min && i < max select i;
        task_2 = arr.Where(i => i > min && i < max);
        WriteResults(task_1, task_2, "Получить числа в заданном диапазоне");

        task_1 = from i in arr where i % 7 == 0 orderby i select i;
        task_2 = arr.Where(i => i % 7 == 0).OrderBy(i => i);
        WriteResults(task_1, task_2, "Получить числа кратные семи. Результат отсортировать по возрастанию");

        task_1 = from i in arr where i % 8 == 0 orderby i descending select i;
        task_2 = arr.Where(i => i % 8 == 0).OrderByDescending(i => i);
        WriteResults(task_1, task_2, "Получить числа кратные восьми. Результат отсортировать по убыванию");


        //2 

        string[] cities = { "Odesa", "Toronto", "New York", "Vancouver", "Kharkiv", "Glasgow", "Atlanta", "Austin", "Durham", "Norwalk", "Newark" };

        var task2_1 = from i in cities select i;
        var task2_2 = cities.Select(i => i);
        WriteResults(task2_1, task2_2, "Получить весь массив городов");

        int letter_count = 5;
        task2_1 = from i in cities where i.Length == letter_count select i;
        task2_2 = cities.Where(i => i.Length == letter_count);
        WriteResults(task2_1, task2_2, "Получить города с длиной названия равной заданному");

        task2_1 = from i in cities where i.ToUpper().StartsWith("A") select i;
        task2_2 = cities.Where(i => i.ToUpper().StartsWith("A"));
        WriteResults(task2_1, task2_2, "Получить города, названия которых начинаются с буквы A");

        task2_1 = from i in cities where i.ToUpper().EndsWith("M") select i;
        task2_2 = cities.Where(i => i.ToUpper().EndsWith("M"));
        WriteResults(task2_1, task2_2, "Получить города, названия которых заканчиваются на букву M");

        task2_1 = from i in cities
                  where i.ToUpper().StartsWith("N")
                  where i.ToUpper().EndsWith("K")
                  select i;
        task2_2 = cities.Where(i => i.ToUpper().StartsWith("N") && i.ToUpper().EndsWith("K"));
        WriteResults(task2_1, task2_2, "Получить города, названия которых начинаются на N и заканчиваются на букву K");

        task2_1 = from i in cities where i.StartsWith("Ne") orderby i descending select i;
        task2_2 = cities.Where(i => i.StartsWith("Ne")).OrderByDescending(i => i);
        WriteResults(task2_1, task2_2, "Получить города, названия которых начинаются на Ne. Результат отсортировать по убыванию");


        //3

        List<Student> students = new List<Student>
        {
            new Student("John", "Broski", 20, "MIT"),
            new Student("Ellen", "Reed", 21, "Hogwarts"),
            new Student("Boris", "Johnson", 18, "MIT"),
            new Student("Boris", "The Animal", 21, "Hogwarts"),
            new Student("Anne", "Brook", 22, "Oxford"),
            new Student("John", "Hicks", 25, "Oxford"),
        };

        var task_3_1 = from i in students select i;
        var task_3_2 = students.Select(i => i);
        WriteResults(task_3_1, task_3_2, "Получить весь массив студентов");

        task_3_1 = from i in students where i.FirstName == "Boris" select i;
        task_3_2 = students.Where(i => i.FirstName == "Boris");
        WriteResults(task_3_1, task_3_2, "Получить студентов с именем Boris");

        task_3_1 = from i in students where i.LastName.StartsWith("Bro") select i;
        task_3_2 = students.Where(i => i.LastName.StartsWith("Bro"));
        WriteResults(task_3_1, task_3_2, "Получить студентов с фамилией, которая начинается с Bro");

        task_3_1 = from i in students where i.Age > 19 select i;
        task_3_2 = students.Where(i => i.Age > 19);
        WriteResults(task_3_1, task_3_2, "Получить студентов, которые старше 19 лет");

        task_3_1 = from i in students where i.Age > 19 && i.Age < 23 select i;
        task_3_2 = students.Where(i => i.Age > 19 && i.Age < 23);
        WriteResults(task_3_1, task_3_2, "Получить студентов, которые старше 19 лет и младше 23 лет");

        task_3_1 = from i in students where i.University == "MIT" select i;
        task_3_2 = students.Where(i => i.University == "MIT");
        WriteResults(task_3_1, task_3_2, "Получить студентов, которые учатся в MIT");

        task_3_1 = from i in students
                   where i.University == "Oxford" && i.Age > 18
                   orderby i.Age descending
                   select i;
        task_3_2 = students.Where(i => i.University == "Oxford" && i.Age > 18).OrderByDescending(i => i.Age);
        WriteResults(task_3_1, task_3_2, "Получить студентов, которые учатся в Oxford и старше 18 лет, отсортировать по убыванию возраста");
    }
}
