using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace hw37
{
    public partial class Form1 : Form
    {
        private List<ThreadInfo> _createdThreads = new List<ThreadInfo>();
        private List<ThreadInfo> _waitingThreads = new List<ThreadInfo>();
        private List<ThreadInfo> _runningThreads = new List<ThreadInfo>();
        private int _threadCounter = 0; 
        private Semaphore _semaphore;

        public Form1()
        {
            InitializeComponent();
            _semaphore = new Semaphore(3, 10);
            textBoxSemaphoreSpaceAvailable.Text = "3"; 

            listBoxCreated.DoubleClick += listBoxCreated_DoubleClick;
            listBoxRunning.DoubleClick += listBoxRunning_DoubleClick;
            textBoxSemaphoreSpaceAvailable.TextChanged += textBoxSemaphoreSpaceAvailable_TextChanged;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var thread in _runningThreads)
            {
                thread.Stop();
            }
            foreach (var threadInfo in _waitingThreads)
            {
                threadInfo.Stop();
            }
        }

        private void buttonCreateThread_Click(object sender, EventArgs e)
        {
            _threadCounter++;
            var threadInfo = new ThreadInfo(_threadCounter);
            _createdThreads.Add(threadInfo);
            listBoxCreated.Items.Add(threadInfo);
        }
        private void listBoxCreated_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxCreated.SelectedItem is ThreadInfo thread)
            {
                _createdThreads.Remove(thread);
                _waitingThreads.Add(thread);
                listBoxCreated.Items.Remove(thread);
                listBoxWaiting.Items.Add(thread);

                MoveToRunning();
            }
        }

        private void MoveToRunning()
        {
            if (_waitingThreads.Count > 0 && _semaphore.WaitOne(0))
            {
                var thread = _waitingThreads[0];
                _waitingThreads.RemoveAt(0);
                listBoxWaiting.Items.Remove(thread);

                _runningThreads.Add(thread);
                listBoxRunning.Items.Add(thread);

                thread.Start();
            }
        }

        private void listBoxRunning_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxRunning.SelectedItem is ThreadInfo thread)
            {
                thread.Stop();

                _runningThreads.Remove(thread);
                listBoxRunning.Items.Remove(thread);
                _semaphore.Release();
                MoveToRunning();
            }
        }
        private void textBoxSemaphoreSpaceAvailable_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSemaphoreSpaceAvailable.Text, out int updLimit) && updLimit > 0)
            {
                int running = _runningThreads.Count;
                if (updLimit < running) 
                {
                    for (int i = running - 1; i >= updLimit; i--) {
                        _runningThreads[i].Stop();
                        listBoxRunning.Items.Remove(_runningThreads[i]);
                        _runningThreads.RemoveAt(i);
                        _semaphore.Release();
                    }
                }

                _semaphore = new Semaphore(updLimit, 10); 
                MoveToRunning(); 
            }
        }
    }
    public class ThreadInfo
    {
        public int Id { get; }
        private Thread _thread;
        private bool _isRunning;
        private int _counter = 0;

        public ThreadInfo(int id)
        {
            Id = id;
            _thread = new Thread(Run);
        }

        public void Start()
        {
            _isRunning = true;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Stop()
        {
            _isRunning = false;

            if (_thread.IsAlive)
            {
                _thread.Join(1000); 
                if (_thread.IsAlive) _thread.Interrupt();
            }
        }

        private void Run()
        {
            try
            {
                while (_isRunning)
                {
                    _counter++;
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadInterruptedException)
            {
            }
        }

        public override string ToString()
        {
            return $"Thread #{Id}";
        }
    }

}
