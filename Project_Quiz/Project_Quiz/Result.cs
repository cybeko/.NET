using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Quiz
{
    public class Result
    {
        public string Username { get; set; }
        public int Score { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }

        public Result(string username, int score, string theme, DateTime date)
        {
            Username = username;
            Score = score;
            Theme = theme;
            Date = date;
        }
    }
    public class Statistics
    {
        private const string ResultsFilePath = "results.json";

        public void SaveResult(Result result)
        {
            List<Result> results = LoadResults();
            results.Add(result);

            File.WriteAllText(ResultsFilePath, JsonSerializer.Serialize(results));
        }

        public List<Result> LoadResults()
        {
            if (!File.Exists(ResultsFilePath))
            {
                return new List<Result>();
            }

            var json = File.ReadAllText(ResultsFilePath);
            return JsonSerializer.Deserialize<List<Result>>(json) ?? new List<Result>();
        }

        public List<Result> GetUserResults(string username)
        {
            var results = LoadResults();
            return results.Where(r => r.Username == username).ToList();
        }

        public List<Result> GetResultsByTheme(string theme)
        {
            var results = LoadResults();
            return results.Where(r => r.Theme.Equals(theme, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
