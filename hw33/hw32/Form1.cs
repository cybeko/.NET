using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFrom_Click(object sender, EventArgs e)
        {
            OpenFileDialog fromFileDialog = new OpenFileDialog();
            if (fromFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFrom.Text = fromFileDialog.FileName;
            }
        }

        private void buttonTo_Click(object sender, EventArgs e)
        {
            SaveFileDialog toFileDialog = new SaveFileDialog();
            if (toFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxTo.Text = toFileDialog.FileName;
            }
        }

        private async void buttonCopy_Click(object sender, EventArgs e)
        {
            string sourcePath = textBoxFrom.Text;
            string destPath = textBoxTo.Text;

            await CopyFileMethodAsync(sourcePath, destPath);
            MessageBox.Show("Copied successfully");
        }
        private async Task CopyFileMethodAsync(string sourcePath, string destinationPath)
        {
            const int bufSize = 4096;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufSize, true))
            using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufSize, true))
            {
                byte[] buffer = new byte[bufSize];
                long totalBytes = sourceStream.Length;
                long copiedBytes = 0;
                int bytesRead;

                progressBar1.Invoke((Action)(() =>
                {
                    progressBar1.Maximum = 100;
                    progressBar1.Value = 0;
                }));

                while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await destStream.WriteAsync(buffer, 0, bytesRead);
                    copiedBytes += bytesRead;

                    int progress = (int)((copiedBytes * 100) / totalBytes);

                    progressBar1.Invoke((Action)(() => progressBar1.Value = progress));
                }
            }
        }
    }
}
