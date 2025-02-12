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

            var fillUnits = GenerateRandomFill(progressBarList.Count);

            var tasks = new List<Task>();
            for (int i = 0; i < progressBarList.Count; i++)
            {
                int fillUnit = fillUnits[i];
                ProgressBar progressBar = progressBarList[i];
                tasks.Add(FillProgressBar(progressBar, fillUnit));
            }

            await Task.WhenAll(tasks);
        }

        private List<int> GenerateRandomFill(int count)
        {
            Random random = new Random();
            var fillUnits = new List<int>();

            for (int i = 0; i < count; i++)
            {
                fillUnits.Add(random.Next(1, 5));
            }

            return fillUnits;
        }

        private async Task FillProgressBar(ProgressBar progressBar, int fillUnit)
        {
            for (int i = 0; i <= 100; i += fillUnit)
            {
                progressBar.Value = Math.Min(i, 100);
                await Task.Delay(50);
            }
            if (progressBar.Value < 100)
            {
                progressBar.Value = 100;
            }
        }
    }
}
