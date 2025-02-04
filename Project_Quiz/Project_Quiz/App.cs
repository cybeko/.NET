using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Quiz
{
    public class App
    {
        private const string UserFilePath = "users.json";
        public void Start()
        {
            var auth = new Authorize(UserFilePath);

            Console.WriteLine("Quiz Game Menu: ");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Log in");

            Console.Write("Choose option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterUser(auth);
                    break;
                case "2":
                    LoginUser(auth);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        private void LoginUser(Authorize auth)
        {
            Console.Write("\nEnter username: ");
            var username = Console.ReadLine();

            Console.Write("Введите пароль: ");
            var password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty");
                return;
            }

            var user = auth.Login(username, password);

            if (user != null)
            {
                Console.WriteLine($"Welcome, {user.Username}!");
                var game = new GameMenu(user.Username);
                game.Menu();
            }
            else
            {
                Console.WriteLine("Invalid login or password");
                Start();
            }
        }

        private void RegisterUser(Authorize auth)
        {
            Console.Write("\nEnter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            Console.Write("Enter birth date (dd.mm.yyyy): ");

            if (!DateTime.TryParse(Console.ReadLine(), out var dateOfBirth))
            {
                Console.WriteLine("\nWrong date format");
                RegisterUser(auth);
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password cannot be empty");
                return;
            }
            var success = auth.Register(username, password, dateOfBirth);

            if (success)
            {
                Start();
            }
            else
            {
                RegisterUser(auth);
            }
        }
    }

}
