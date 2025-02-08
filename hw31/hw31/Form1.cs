using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace hw31
{
    public partial class Form1 : Form
    {
        private bool isSearching = false;
        private bool stopSearch = false;
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
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
                string dirPath = @"C:\";

                string searchMask = textBoxMask.Text;
                string searchPhrase = textBoxPhrase.Text;

                listView.Items.Clear();

                await SearchDirectoryAsync(dirPath, searchMask, searchPhrase);
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

        private async Task SearchDirectoryAsync(string dirPath, string searchMask, string searchPhrase)
        {
            try
            {
                if (stopSearch)
                    return;

                var dataToCheck = Directory.GetFileSystemEntries(dirPath, searchMask);

                foreach (var item in dataToCheck)
                {
                    if (stopSearch)
                        return;

                    if (File.Exists(item))
                    {
                        string content = File.ReadAllText(item);
                        if (content.Contains(searchPhrase))
                        {
                            var listViewItem = new ListViewItem(Path.GetFileName(item));
                            listViewItem.SubItems.Add(item);
                            listView.Items.Add(listViewItem);
                        }
                    }
                    else if (Directory.Exists(item))
                    {
                        var listViewItem = new ListViewItem(Path.GetFileName(item));
                        listViewItem.SubItems.Add(item);
                        listView.Items.Add(listViewItem);
                    }
                }

                var subdirs = Directory.GetDirectories(dirPath);
                var tasks = new List<Task>();

                foreach (var subdir in subdirs)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        await SearchDirectoryAsync(subdir, searchMask, searchPhrase);
                    }));
                }

                await Task.WhenAll(tasks);
            }
            catch (UnauthorizedAccessException)
            {
                return;
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
    }
}
