using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj_BannedWordsSearch
{
    public partial class Form1 : Form
    {
        private bool isSearching = false;
        private bool stopSearch = false;
        private List<string> bannedWords = new List<string>();
        private string reportDir;
        private Report report = new Report();

        public Form1()
        {
            InitializeComponent();
            LoadBannedWords();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            if (isSearching)
            {
                MessageBox.Show("Search is in progress.");
                return;
            }

            labelStatus.Text = "Scanning...";

            stopSearch = false;
            await StartSearchAsync();

            labelStatus.Text = "Search complete.";
        }

        private async Task StartSearchAsync()
        {
            isSearching = true;
            try
            {
                if (string.IsNullOrEmpty(reportDir))
                {
                    MessageBox.Show("Please select a report directory first.");
                    return;
                }

                // Set the directory to start the scan from
                string dirPath = @"C:\";

                await SearchDirectoryAsync(dirPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                isSearching = false;
            }
        }

        private async Task SearchDirectoryAsync(string dirPath)
        {
            try
            {
                if (stopSearch)
                    return;

                // Get all files and folders
                var dataToCheck = Directory.GetFileSystemEntries(dirPath, "*.txt");

                foreach (var item in dataToCheck)
                {
                    if (stopSearch)
                        return;

                    if (File.Exists(item))
                    {
                        // Check each .txt file for banned words
                        await CheckForBannedWordsAsync(item);
                    }
                }

                // Get all subdirectories to search recursively
                var subdirs = Directory.GetDirectories(dirPath);
                var tasks = new List<Task>();

                foreach (var subdir in subdirs)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        await SearchDirectoryAsync(subdir);
                    }));
                }

                await Task.WhenAll(tasks);
            }
            catch (UnauthorizedAccessException)
            {
                // If access is denied, skip and continue with other directories
                return;
            }
        }

        private async Task CheckForBannedWordsAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string fileContent = await File.ReadAllTextAsync(filePath);
                    bool foundBannedWord = false;

                    foreach (var bannedWord in bannedWords)
                    {
                        int count = Regex.Matches(fileContent, @"\b" + Regex.Escape(bannedWord) + @"\b", RegexOptions.IgnoreCase).Count;

                        if (count > 0)
                        {
                            fileContent = Regex.Replace(fileContent, @"\b" + Regex.Escape(bannedWord) + @"\b", "***", RegexOptions.IgnoreCase);
                            report.ProcessWord(bannedWord, count);  // Increment count in report
                            foundBannedWord = true;
                        }
                    }

                    if (foundBannedWord)
                    {
                        string fileName = Path.GetFileName(filePath);
                        string newFilePath = Path.Combine(reportDir, fileName);
                        await File.WriteAllTextAsync(newFilePath, fileContent);  // Save the file with replaced words

                        long fileSize = new FileInfo(filePath).Length; // Get file size in bytes
                        report.filesInfo.Add(filePath, (int)fileSize); // Add to report

                        report.CountTotalWordsReplaced();
                        report.SaveReport(reportDir);

                        // Optionally, show the user some feedback
                        Console.WriteLine($"File processed and saved to: {newFilePath}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle file-specific exceptions (e.g., access denied)
                    return;
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (isSearching)
            {
                stopSearch = true;
                labelStatus.Text = "Stopping search...";
            }
        }

        private void buttonSelectReportDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    reportDir = folderDialog.SelectedPath;
                    textBoxReportDir.Text = reportDir;
                }
            }
        }

        private void LoadBannedWords()
        {
            string filePath = "banned_words.txt";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                bannedWords = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
            }
        }
    }

    // Report class
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
            foreach (var entry in wordPopularity)
            {
                totalWordReplaced += entry.Value;
            }
        }

        public void SaveReport(string reportDir)
        {
            string reportPath = Path.Combine(reportDir, "report.txt");
            List<string> reportLines = new List<string>();

            reportLines.Add("\nFile Information:");
            foreach (var entry in filesInfo)
            {
                reportLines.Add($"{entry.Key}: {entry.Value} bytes");
            }

            reportLines.Add($"\nTotal words replaced: {totalWordReplaced}");

            var topTenWords = wordPopularity
                .OrderByDescending(entry => entry.Value)
                .Take(10)
                .ToList();

            reportLines.Add("\nTop 10 Most Popular Banned Words:");
            int rank = 1;
            foreach (var entry in topTenWords)
            {
                reportLines.Add($"{rank}. {entry.Key}: {entry.Value} occurrences");
                rank++;
            }

            File.WriteAllLines(reportPath, reportLines);
        }
    }
}
