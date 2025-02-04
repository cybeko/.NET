using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw29_thread1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(100000, "Alpha Bank", 5);
            Console.WriteLine(bank.ToString());

            bank.Money = 100500;
            bank.Name = "New Bank";
            bank.Percent = 13;
        }
    }
}
