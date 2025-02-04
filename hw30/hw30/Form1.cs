using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace hw30
{
    public partial class ProcessManager : Form
    {
        public ProcessManager()
        {
            InitializeComponent();
            LoadProcessList();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string proc = textBoxProcName.Text.Trim();
            if (!string.IsNullOrEmpty(proc))
            {

                    Process myProcess = new Process();
                    myProcess.StartInfo = new ProcessStartInfo(proc);
                    myProcess.Start();
                    MessageBox.Show($"Started process: {proc}");
                    LoadProcessList();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (listBoxProc.SelectedItem != null)
            {
                string selectedProcessName = listBoxProc.SelectedItem.ToString();

                Process[] processes = Process.GetProcessesByName(selectedProcessName);

                foreach (Process process in processes)
                {
                    process.Kill();
                }

                MessageBox.Show($"Killed process: {selectedProcessName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProcessList();
            }
        }
        private void LoadProcessList()
        {
            listBoxProc.Items.Clear();
            var processNames = Process.GetProcesses().Select(p => p.ProcessName).Distinct().OrderBy(name => name);

            foreach (var proc in processNames)
            {
                listBoxProc.Items.Add(proc);
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadProcessList();
        }
    }
}
