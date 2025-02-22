using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace proj_BannedWordsSearch
{
    public partial class Form1 : Form
    {
        private List<string> bannedWords = new List<string>();
        private string filePath = "banned_words.txt";
        private string testFilePath = "D:\\BG3_Mods\\Test.txt";
        private string reportDir;
        private Report report = new Report();
        bool isSearching;
        public Form1()
        {
            InitializeComponent();
            LoadBannedWords();
            listBoxBannedWords.MouseDoubleClick += listBoxBannedWords_MouseDoubleClick;
        }

        private void buttonEnterWord_Click(object sender, EventArgs e)
        {
            string newWord = textBoxBannedWord.Text.Trim();
            if (!string.IsNullOrEmpty(newWord) && !bannedWords.Contains(newWord))
            {
                bannedWords.Add(newWord);
                listBoxBannedWords.Items.Add(newWord);
                SaveBannedWords();
                textBoxBannedWord.Clear();
            }
        }

        private void SaveBannedWords()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bannedWords, Newtonsoft.Json.Formatting.Indented));
        }

        private void LoadBannedWords()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                bannedWords = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
                listBoxBannedWords.Items.AddRange(bannedWords.ToArray());

                foreach (var word in bannedWords)
                {
                    if (!report.wordPopularity.ContainsKey(word))
                        report.wordPopularity[word] = 0;
                }

            }
        }
        private void listBoxBannedWords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxBannedWords.SelectedItem != null)
            {
                string selectedWord = listBoxBannedWords.SelectedItem.ToString();
                bannedWords.Remove(selectedWord);
                listBoxBannedWords.Items.Remove(selectedWord);
                SaveBannedWords();
            }
        }
        private void CheckForBannedWords(string filePath)
        {
            if (string.IsNullOrEmpty(reportDir))
            {
                MessageBox.Show("Select a destination directory first.");
                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    bool foundBannedWord = false;

                    foreach (var bannedWord in bannedWords)
                    {
                        int count = Regex.Matches(fileContent, @"\b" + Regex.Escape(bannedWord) + @"\b", RegexOptions.IgnoreCase).Count;

                        if (count > 0)
                        {
                            fileContent = Regex.Replace(fileContent, @"\b" + Regex.Escape(bannedWord) + @"\b", "***", RegexOptions.IgnoreCase);
                            report.ProcessWord(bannedWord, count);
                            foundBannedWord = true;
                        }
                    }

                    if (!foundBannedWord)
                    {
                        return;
                    }

                    string fileName = Path.GetFileName(filePath);
                    string newFilePath = Path.Combine(reportDir, fileName);
                    File.WriteAllText(newFilePath, fileContent);

                    long fileSize = new FileInfo(filePath).Length;
                    report.filesInfo.Add(filePath, (int)fileSize);

                    report.CountTotalWordsReplaced();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing the file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("File not found");
            }
        }
        private void buttonSelectReportDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog chooseFolder = new FolderBrowserDialog())
            {
                if (chooseFolder.ShowDialog() == DialogResult.OK)
                {
                    reportDir = chooseFolder.SelectedPath;
                    textBoxReportDir.Text = reportDir;
                }
            }
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            string rootDirectory = @"C:\";
            isSearching = true;
            try
            {
                labelStatus.Text = "Searching...";
                await SearchDirectoryAsync(rootDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                isSearching = false;
                labelStatus.Text = "Search completed";
                SaveReport();
            }
        }
        private void SaveReport()
        {
            try
            {
                report.SaveReport(reportDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving report: " + ex.Message);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSearching)
            {
                SaveReport();
            }
        }
        private async Task SearchDirectoryAsync(string dirPath)
        {
            try
            {
                var allFiles = Directory.GetFileSystemEntries(dirPath, "*.txt");
                var tasks = new List<Task>();

                foreach (var file in allFiles)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        await ProcessFileAsync(file);
                    }));
                }
                await Task.WhenAll(tasks);

                var subdirs = Directory.GetDirectories(dirPath);
                foreach (var subdir in subdirs)
                {
                    await SearchDirectoryAsync(subdir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }

        private async Task ProcessFileAsync(string filePath)
        {
            try
            {
                await Task.Run(() =>
                {
                    CheckForBannedWords(filePath);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing file {filePath}: {ex.Message}");
            }
        }
    }


}
