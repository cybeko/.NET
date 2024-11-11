using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw21_generic
{
    public class Cafe<T> : IEnumerable<T> where T : Worker
    {
        public string Name { get; private set; }
        public T[] Workers { get; private set; }
        public Cafe(int count, string name)
        {
            Workers = new T[count];
            Name = name;
        }
        public void PrintAllPlayers()
        {
            Console.WriteLine($"\tCafe Name: {Name}\n\tWorkers Info: ");
            foreach (var worker in this)
            {
                if (worker != null)
                {
                    Console.WriteLine($"Name: {worker.Name} {worker.LastName}, Age: {worker.Age}");
                }
            }
        }

        public void AddWorker(T worker)
        {
            for (int i = 0; i < Workers.Length; i++)
            {
                if (Workers[i] == null)
                {
                    Workers[i] = worker;
                    return;
                }
            }
            throw new InvalidOperationException("Cannot add more workers. No more space in cafe.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var worker in Workers)
            {
                if (worker != null)
                {
                    yield return worker;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Worker
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Worker(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }
    }
}
