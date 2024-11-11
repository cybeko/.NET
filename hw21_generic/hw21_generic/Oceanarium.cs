using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Oceanarium<T> : IEnumerable<T> where T : SeaCreature
    {
        public T[] SeaCreatures { get; private set; }

        public Oceanarium(int count)
        {
            SeaCreatures = new T[count];
        }

        public void PrintAllCreatures()
        {
            Console.WriteLine("\tInfo: ");

            foreach (var creature in this)
            {
                if (creature != null)
                {
                    Console.WriteLine($"Type: {creature.Type}, Name: {creature.Name}");
                }
            }
        }

        public void AddCreature(T creature)
        {
            for (int i = 0; i < SeaCreatures.Length; i++)
            {
                if (SeaCreatures[i] == null)
                {
                    SeaCreatures[i] = creature;
                    return;
                }
            }
            throw new InvalidOperationException("Cannot add more creatures. No more space in oceanarium.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var creature in SeaCreatures)
            {
                if (creature != null)
                {
                    yield return creature;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public abstract class SeaCreature
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public SeaCreature()
        {
            Type = string.Empty;
            Name = string.Empty;
        }
    }
    public class Fish : SeaCreature
    {
        public Fish(string name)
        {
            Type = "Fish";
            Name = name;
        }
    }
    public class Mammal : SeaCreature
    {
        public Mammal(string name)
        {
            Type = "Mammal";
            Name = name;
        }
    }
    public class Crustacean : SeaCreature
    {
        public Crustacean(string name)
        {
            Type = "Crustacean";
            Name = name;
        }
    }
}
