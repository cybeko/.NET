namespace proj_BannedWordsSearch
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "{9EABC4C7-5A6B-4306-B53C-FFEF67EE8954}");
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Program is already running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            GC.KeepAlive(mutex);
        }
    }
}