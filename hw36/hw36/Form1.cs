using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw36
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            string text = textBoxText.Text.Trim();

            if (text.Length == 0)
            {
                MessageBox.Show("Text box is empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = "Report:\n";

            if (checkBoxSentenceCount.Checked)
            {
                int sentenceCount = await CountSentences(text);
                message += $"Total Sentences: {sentenceCount}\n";
            }

            if (checkBoxSymbolCount.Checked)
            {
                int symbolCount = await CountSymbols(text);
                message += $"Total Symbols: {symbolCount}\n";
            }

            if (checkBoxWordCount.Checked)
            {
                int wordCount = await CountWords(text);
                message += $"Total Words: {wordCount}\n";
            }

            if (checkBoxInterrogativeSentenceCount.Checked)
            {
                int interrogativeCount = await CountInterrogativeSentences(text);
                message += $"Interrogative Sentences: {interrogativeCount}\n";
            }

            if (checkBoxExclamatorySentenceCount.Checked)
            {
                int exclamatoryCount = await CountExclamatorySentences(text);
                message += $"Exclamatory Sentences: {exclamatoryCount}\n";
            }
            if (checkBoxSaveToFile.Checked)
            {
                string path = "report.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    await sw.WriteAsync(message);
                }

                message += $"Report saved to file: {path}";
            }

            MessageBox.Show(message, "Analysis report", MessageBoxButtons.OK);
        }
        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxCheckAll.Checked;

            checkBoxSentenceCount.Checked = isChecked;
            checkBoxSymbolCount.Checked = isChecked;
            checkBoxWordCount.Checked = isChecked;
            checkBoxInterrogativeSentenceCount.Checked = isChecked;
            checkBoxExclamatorySentenceCount.Checked = isChecked;
        }

        private async Task<int> CountSentences(string text)
        {
            return await Task.Run(() => Regex.Matches(text, @"[.!?](\s|$)").Count);
        }

        private async Task<int> CountSymbols(string text)
        {
            return await Task.Run(() => text.Count());
        }

        private async Task<int> CountWords(string text)
        {
            return await Task.Run(() => Regex.Matches(text, @"\b\w+\b").Count);
        }

        private async Task<int> CountExclamatorySentences(string text)
        {
            return await Task.Run(() => Regex.Matches(text, @"!+(\s|$)").Count);
        }

        private async Task<int> CountInterrogativeSentences(string text)
        {
            return await Task.Run(() => Regex.Matches(text, @"\?+(\s|$)").Count);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxText.Clear();
        }
    }
}
