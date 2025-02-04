using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Quiz
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public string Theme { get; set; }

        public Quiz(string theme)
        {
            Theme = theme;
            Questions = LoadQuestionsFromJson();

            if (theme.Equals("Mixed", StringComparison.OrdinalIgnoreCase))
            {
                Questions = Questions.OrderBy(q => Guid.NewGuid()).Take(10).ToList();
            }
            else
            {
                Questions = Questions.Where(q => q.Theme.Equals(theme, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        private List<Question> LoadQuestionsFromJson()
        {
            string json = File.ReadAllText("questions.json");
            return JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
        }
        public void Play(ref int score)
        {
            foreach (var question in Questions)
            {
                Console.WriteLine();
                Console.WriteLine(question.QuestionText);
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].AnswerText}");
                }
                Console.Write("\nYour answer: ");
                if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= question.Answers.Count)
                {
                    if (question.Answers[id - 1].IsCorrect)
                        score++;
                }
            }
        }
    }
    public class Question
    {
        public string QuestionText { get; set; }
        public string Theme { get; set; }
        public List<Answer> Answers { get; set; }
        public Question(string questionText, string theme, List<Answer> answers)
        {
            QuestionText = questionText;
            Theme = theme;
            Answers = answers ?? new List<Answer>();
        }
    }
    public class Answer
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public Answer(string answerText, bool isCorrect)
        {
            AnswerText = answerText;
            IsCorrect = isCorrect;
        }
    }
}
