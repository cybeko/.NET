using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw25
{
    public class Money
    {
        private int hryvnia, kopiyka;
        private static FileStream fs;

        static Money()
        {
            fs = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write);
        }

        public Money(int hryvnia, int kopiyka)
        {
            if (hryvnia < 0 || kopiyka < 0)
                throw new ArgumentException("Sum cannot be negative");

            this.hryvnia = hryvnia;
            this.kopiyka = kopiyka;
            AdjustCurrency();

            Log($"Object created: {this}");
        }

        private void AdjustCurrency()
        {
            hryvnia += kopiyka / 100;
            kopiyka %= 100;
        }

        private static void Log(string str)
        {
            using (StreamWriter log = new StreamWriter(fs, leaveOpen: true))
            {
                log.WriteLine($"{DateTime.Now}: {str}");
                log.Flush();
            }
        }

        public static Money operator +(Money a, Money b)
        {
            int hryv = a.hryvnia + b.hryvnia;
            int kop = a.kopiyka + b.kopiyka;
            Money res = new Money(hryv, kop);
            Log($"Addition: {a} + {b} = {res}");
            return res;
        }

        public static Money operator -(Money a, Money b)
        {
            int totalKopA = a.hryvnia * 100 + a.kopiyka;
            int totalKopB = b.hryvnia * 100 + b.kopiyka;

            if (totalKopA < totalKopB)
            {
                Log($"Error doing subtraction: {a} - {b}");
                throw new InvalidOperationException("Sum cannot be negative.");
            }

            int resKop = totalKopA - totalKopB;
            Money res = new Money(resKop / 100, resKop % 100);
            Log($"Subtraction: {a} - {b} = {res}");
            return res;
        }

        public static Money operator ++(Money a)
        {
            a.kopiyka++;
            a.AdjustCurrency();
            Log($"Increment: {a}");
            return a;
        }

        public static Money operator --(Money a)
        {
            if (a.hryvnia == 0 && a.kopiyka == 0)
            {
                Log($"Error decrementing: {a}");
                throw new InvalidOperationException("Sum cannot be negative.");
            }

            a.kopiyka--;
            if (a.kopiyka < 0)
            {
                a.hryvnia--;
                a.kopiyka += 100;
            }

            Log($"Decrement: {a}");
            return a;
        }

        public override string ToString() => $"{hryvnia} hryv {kopiyka} kop";
        public static void CloseLog()
        {
            if (fs != null)
            {
                fs.Close();
                fs = null;
            }
        }
    }
}
