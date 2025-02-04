using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Xml.Linq;

namespace hw29_thread1
{
    class Bank
    {
        private int _money;
        private string _name;
        private int _percent;
        private readonly object _lock = new object();

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                CreateThread();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                CreateThread();
            }
        }

        public int Percent
        {
            get => _percent;
            set
            {
                _percent = value;
                CreateThread();
            }
        }
        public Bank(int money, string name, int percent)
        {
            _money = money;
            _name = name;
            _percent = percent;
        }
        public override string ToString()
        {
            return $"Bank: {_name}, Money: {_money}, Percent: {_percent}%";
        }
        private void CreateThread()
        {
            Thread writeDataThread = new Thread(WriteToFile);
            writeDataThread.Start();
            writeDataThread.Join();
        }
        private void WriteToFile()
        {
            string filePath = "Bank.txt";
            string data = ToString();

            lock (_lock)
            {
                File.AppendAllText(filePath, data + "\n");
            }
        }
    }
}
