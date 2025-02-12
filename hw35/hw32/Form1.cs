using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw32
{
    public delegate void CopyingThread(string sourcePath, string destPath);

    public partial class Form1 : Form
    {
        private SynchronizationContext sC = null;
        private CancellationTokenSource cancellationTokenSource;
        private long bytes = 0;

        public Form1()
        {
            InitializeComponent();
            sC = SynchronizationContext.Current;
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

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            bytes = 0; 

            Task.Factory.StartNew(() => CopyFileMethod(textBoxFrom.Text, textBoxTo.Text, cancellationTokenSource.Token),
                                  cancellationTokenSource.Token)
                          .ContinueWith(t => ShowFinalMessage(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ShowFinalMessage()
        {
            MessageBox.Show($"Copied {bytes} bytes");
        }

        private void CopyFileMethod(string sourcePath, string destinationPath, CancellationToken token)
        {
            const int bufSize = 4096;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buf = new byte[bufSize];

                long totalBytes = sourceStream.Length;

                sC.Send(_ => progressBar1.Maximum = 100, null);
                sC.Send(_ => progressBar1.Value = 0, null);

                while (!token.IsCancellationRequested)
                {
                    int bytesRead = sourceStream.Read(buf, 0, buf.Length);
                    if (bytesRead == 0) break;

                    destStream.Write(buf, 0, bytesRead);
                    bytes += bytesRead;

                    int progress = (int)((bytes * 100) / totalBytes);

                    sC.Send(_ => progressBar1.Value = progress, null);
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
