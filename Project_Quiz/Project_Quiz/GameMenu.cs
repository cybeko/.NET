using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Quiz
{
    public class GameMenu
    {
        private Statistics _statistics = new Statistics();
        private string _currentUser;

        public GameMenu(string loggedInUser)
        {
            _currentUser = loggedInUser;
        }

        public void Menu()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Start game");
            Console.WriteLine("2. Get my game results");
            Console.WriteLine("3. Get top results by theme");
            Console.WriteLine("4. Change password");
            Console.WriteLine("5. Change date");
            Console.WriteLine("6. Exit");

            Console.Write("\nChoose option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartQuiz();
                    break;
                case "2":
                    ShowCurrentUserResults();
                    break;
                case "3":
                    ShowResultsByTheme();
                    break;
                case "4":
                    UpdatePassword();
                    break;
                case "5":
                    UpdateDateOfBirth();
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Menu();
                    break;
            }
        }

        private void StartQuiz()
        {
            Console.Write("\nEnter quiz theme (Mathematics, Literature, Geography, Astronomy, Mixed): ");
            var theme = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(theme))
            {
                Console.WriteLine("Invalid theme");
                StartQuiz();
                return;
            }

            var quiz = new Quiz(theme);
            if (quiz.Questions.Count == 0)
            {
                Console.WriteLine($"No questions for the theme: {theme}");
                StartQuiz();
                return;
            }

            int score = 0;
            quiz.Play(ref score);

            var result = new Result(_currentUser, score, theme, DateTime.Now);
            _statistics.SaveResult(result);

            Console.WriteLine($"Your score: {score}/{quiz.Questions.Count}");
            Menu();
        }

        private void ShowCurrentUserResults()
        {
            var results = _statistics.GetUserResults(_currentUser);
            if (!results.Any())
            {
                Console.WriteLine("No results found for this user");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine($"Theme: {result.Theme}, Score: {result.Score}, Date: {result.Date}");
                }
            }
            Menu();
        }

        private void ShowResultsByTheme()
        {
            Console.Write("Enter theme: ");
            var theme = Console.ReadLine();

            if (string.IsNullOrEmpty(theme))
            {
                Console.WriteLine("Invalid input");
                Menu();
                return;
            }

            var results = _statistics.GetResultsByTheme(theme);
            if (!results.Any())
            {
                Console.WriteLine("No results found for the theme");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine($"User: {result.Username}, Score: {result.Score}, Date: {result.Date}");
                }
            }
            Menu();
        }
        private void UpdatePassword()
        {
            Console.Write("Enter new password: ");
            var usrPass = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(usrPass))
            {
                Console.WriteLine("Password cannot be empty");
                Menu();
                return;
            }

            var auth = new Authorize("users.json");
            var success = auth.UpdatePassword(_currentUser, usrPass);

            if (!success)
            {
                Console.WriteLine("Failed to update password");
            }
            Menu();
        }

        private void UpdateDateOfBirth()
        {
            Console.Write("Enter new date of birth (dd.mm.yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var usrDate))
            {
                Console.WriteLine("Invalid date format");
                Menu();
                return;
            }

            var auth = new Authorize("users.json");
            var success = auth.UpdateDateOfBirth(_currentUser, usrDate);

            if (!success)
            {
                Console.WriteLine("Failed to update date of birth");
            }
            Menu();
        }
    }
}
