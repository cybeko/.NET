using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace hw32
{
    public delegate void CopyingThread(string sourcePath, string destPath);

    public partial class Form1 : Form
    {
        private CopyingThread copyThread = null;
        private SynchronizationContext sC = null;
        private AsyncCallback finalMessage = null;

        public Form1()
        {
            InitializeComponent();
            sC = SynchronizationContext.Current;
            copyThread = CopyFileMethod;

            finalMessage = ShowFinalMessage;
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
            IAsyncResult ar = copyThread.BeginInvoke(textBoxFrom.Text, textBoxTo.Text, finalMessage, null);
        }
        private void ShowFinalMessage(IAsyncResult ar)
        {
            MessageBox.Show("Copied successfully", "Success");
        }
        private void CopyFileMethod(string sourcePath, string destinationPath)
        {
            const int bufSize = 4096;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buf = new byte[bufSize];

                long totalBytes = sourceStream.Length;
                long copiedBytes = 0;
                int bytesRead;

                sC.Send(_ => progressBar1.Maximum = 100, null);
                sC.Send(_ => progressBar1.Value = 0, null);

                while ((bytesRead = sourceStream.Read(buf, 0, buf.Length)) > 0)
                {
                    destStream.Write(buf, 0, bytesRead);
                    copiedBytes += bytesRead;

                    int progress = (int)((copiedBytes * 100) / totalBytes);

                    sC.Send(_ => progressBar1.Value = progress, null);
                }
            }
        }
    }
}
