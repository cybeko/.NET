using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw34
{
    public partial class Form1 : Form
    {
        private string path = "students.json";
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            LoadStudents();
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Incorrect age.");
                return;
            }

            Student newStudent = new Student(
                textBoxName.Text,
                textBoxLastName.Text,
                age,
                textBoxGroup.Text
            );

            await AddStudent(newStudent);
        }

        private async Task AddStudent(Student student)
        {
            students = await ReadStudents();
            students.Add(student);

            await WriteStudents(students);
            LoadStudents();
        }

        private async void LoadStudents()
        {
            students = await ReadStudents();
            listBox.Items.Clear();

            foreach (var stud in students)
            {
                listBox.Items.Add($"{stud.Name} {stud.LastName}, {stud.Age}, group {stud.Group}");
            }

            OutputYoungestStudent();
        }

        private async Task<List<Student>> ReadStudents()
        {
            if (!File.Exists(path)) return new List<Student>();

            try
            {
                string json = await File.ReadAllTextAsync(path);
                return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
            catch
            {
                return new List<Student>();
            }
        }

        private async Task WriteStudents(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

        private void OutputYoungestStudent()
        {
            if (students.Count == 0) return;

            Student youngest = students.OrderBy(s => s.Age).First();
            MessageBox.Show($"Youngest student: {youngest.Name} {youngest.LastName}, {youngest.Age}, group {youngest.Group}");
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }

        public Student(string name, string lastName, int age, string group)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Group = group;
        }
    }
}
