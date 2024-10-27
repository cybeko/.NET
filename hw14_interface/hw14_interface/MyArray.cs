using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14_interface
{
    internal class MyArray : ICalc, ICalc2, IOutput
    {
        public int Size { get; }
        public int[] Array { get; private set; }

        private readonly static Random Random = new Random();

        public MyArray(int size)
        {
            Size = size;
            Array = new int[size];
            for (int i = 0; i < Size; i++)
            {
                Array[i] = Random.Next(0, 16);
            }
        }
        public MyArray(int size, int min, int max)
        {
            Size = size;
            Array = new int[size];
            for (int i = 0; i < Size; i++)
            {
                Array[i] = Random.Next(min, max+1);
            }
        }

        public void Print()
        {
            foreach (int i in Array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public int Less(int valueToCompare)
        {
            int count = 0;

            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] < valueToCompare)
                    count++;
            }

            return count;
        }

        public int Greater(int valueToCompare)
        {
            int count = 0;

            for (int i = 0; i < Array.Length; i++) {
                if (Array[i] > valueToCompare)
                    count++;
            }

            return count;
        }
        public int CountDistinct()
        {
            int count = 0;
            bool isDistinct;

            for (int i = 0; i < Array.Length; i++) {
                isDistinct = true;

                for (int j = 0; j < i; j++) {
                    if (Array[i] == Array[j]) {
                        isDistinct = false;
                        break;
                    }
                }
                if (isDistinct)
                    count++;
            }

            return count;
        }

        public int EqualToValue(int value)
        {
            int count = 0;
            for (int i = 0; i < Array.Length; i++) {
                if (Array[i] == value)
                    count++;
            }
            return count;
        }

        public void ShowOdd()
        {
            for (int i = 0; i < Array.Length; i++) {
                if (Array[i] % 2 == 1)
                    Console.Write(Array[i] + " ");
            }
        }

        public void ShowEven()
        {
            for (int i = 0; i < Array.Length; i++) {
                if (Array[i] % 2 == 0)
                    Console.Write(Array[i] + " ");
            }
        }
    }
}
