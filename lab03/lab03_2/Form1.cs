using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            List<ProgressBar> progressBarList = new List<ProgressBar> { progressBar1, progressBar2, progressBar3, progressBar4, progressBar5 };

            foreach (var progressBar in progressBarList)
            {
                progressBar.Value = 0;
            }

            var delays = GenerateRandDelay(progressBarList.Count);
            var tasks = new List<Task>();

            for (int i = 0; i < progressBarList.Count; i++)
            {
                int delay = delays[i];
                ProgressBar progressBar = progressBarList[i];
                tasks.Add(RunProgressBar(progressBar, delay));
            }

            await Task.WhenAll(tasks);
        }

        private List<int> GenerateRandDelay(int count)
        {
            Random random = new Random();
            var delays = new List<int>();

            for (int i = 0; i < count; i++)
            {
                delays.Add(random.Next(20, 100)); 
            }

            return delays;
        }

        private async Task RunProgressBar(ProgressBar progressBar, int delay)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;
                await Task.Delay(delay);
            }
        }
    }
}
