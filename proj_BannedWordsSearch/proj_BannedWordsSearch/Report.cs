using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_BannedWordsSearch
{
    public class Report
    {
        public Dictionary<string, int> wordPopularity = new Dictionary<string, int>();
        public Dictionary<string, int> filesInfo = new Dictionary<string, int>();
        public int totalWordReplaced = 0;
        public void ProcessWord(string word, int count)
        {
            if (wordPopularity.ContainsKey(word))
            {
                wordPopularity[word] += count;
            }
            else
            {
                wordPopularity[word] = count;
            }
        }
        public void CountTotalWordsReplaced()
        {
            totalWordReplaced = 0;

            foreach (var word in wordPopularity)
            {
                totalWordReplaced += word.Value;
            }
        }

        public void SaveReport(string reportDir)
        {
            string reportPath = Path.Combine(reportDir, "scan_report.txt");
            List<string> lines = new List<string>();

            lines.Add("All paths:");
            foreach (var entry in filesInfo)
            {
                lines.Add($"{entry.Key}: {entry.Value} bytes");
            }

            lines.Add($"\nTotal words replaced: {totalWordReplaced}");

            var topTenWords = wordPopularity
                .OrderByDescending(entry => entry.Value)
                .Take(10)
                .ToList();

            lines.Add("\nTop 10 most popular banned words:");
            int rank = 1;
            foreach (var entry in topTenWords)
            {
                lines.Add($"{rank}. {entry.Key}: {entry.Value} occurrences");
                rank++;
            }
            File.WriteAllLines(reportPath, lines);
        }
    }
}
