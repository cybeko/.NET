using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_Quiz
{
    public class Authorize
    {
        private readonly string filePath;
        public Authorize(string filePath)
        {
            this.filePath = filePath;
        }
        public User Login(string username, string password)
        {
            var users = GetUsers();
            var user = users.First(u => u.Username == username && u.Password == password);
            return user;
        }
        public bool Register(string username, string password, DateTime dob)
        {
            var users = GetUsers();

            if (!IsValidUsername(username))
            {
                Console.WriteLine("Password has to be longer than 1 symbol and can't contain special symbols");
                return false;
            }
            if (!IsValidPassword(password))
            {
                Console.WriteLine("Password has to be longer than 6 symbols and can't contain special symbols");
                return false;
            }
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("this user already exists");
                return false;
            }

            var newUser = new User(username, password, dob);
            users.Add(newUser);

            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
            Console.WriteLine("User registered successfully");
            return true;
        }
        private bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[A-Za-z]{2,}$");
        }
        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^[A-Za-z0-9]{7,}$");
        }
        public bool UpdatePassword(string username, string newPassword)
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }

            if (!IsValidPassword(newPassword))
            {
                Console.WriteLine("Invalid password");
                return false;
            }

            user.UpdatePassword(newPassword);
            SaveUsers(users);
            Console.WriteLine("Password updated successfully");
            return true;
        }

        public bool UpdateDateOfBirth(string username, DateTime newDateOfBirth)
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }

            user.UpdateDateOfBirth(newDateOfBirth);
            SaveUsers(users);
            Console.WriteLine("Date of birth updated successfully");
            return true;
        }

        private void SaveUsers(List<User> users)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
        }

        private List<User> GetUsers()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            var json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
    }
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public User(string username, string password, DateTime dateOfBirth)
        {
            Username = username;
            Password = password;
            DateOfBirth = dateOfBirth;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void UpdateDateOfBirth(DateTime newDateOfBirth)
        {
            DateOfBirth = newDateOfBirth;
        }
    }
}
