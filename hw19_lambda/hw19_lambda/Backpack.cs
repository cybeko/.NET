using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw19_lambda
{
    public delegate void AddObjectHandler(BackpackObject obj);

    public class Backpack
    {
        private string Color { get; set; }
        private string Manufacturer { get; set; }
        private string Fabric { get; set; }
        private double Weight { get; set; }
        private double Volume { get; set; }
        private List<BackpackObject> Objects;
        public event AddObjectHandler? ObjectAdded;
        public Backpack()
        {
            Color = string.Empty;
            Manufacturer = string.Empty;
            Fabric = string.Empty;
            Weight = 0.0;
            Volume = 0.0;
            Objects = new List<BackpackObject>();
            ObjectAdded += OnObjectAdded;
        }
        public Backpack(string color, string manufacturer, string fabric, double weight, double volume, List<BackpackObject> objects)
        {
            Color = color;
            Manufacturer = manufacturer;
            Fabric = fabric;
            Volume = volume;
            Objects = objects ?? new List<BackpackObject>();
            Weight = Objects.Sum(obj => obj.Weight);

            ObjectAdded += OnObjectAdded;
        }
        public Backpack(string color, string manufacturer, string fabric, double weight, double volume)
        {
            Color = color;
            Manufacturer = manufacturer;
            Fabric = fabric;
            Weight = weight;
            Volume = volume;
            Objects = new List<BackpackObject>();
            ObjectAdded += OnObjectAdded;
        }
        public void AddObject(BackpackObject obj)
        {
            double currentVolume = GetBackpackVolume();

            if (currentVolume + obj.GetVolume() > Volume)
            {
                throw new InvalidOperationException($"Backpack is full: cannot add object '{obj.Name}'");
            }

            Objects.Add(obj);
            Weight += obj.Weight;
            ObjectAdded?.Invoke(obj);
        }
        public void AddObject(List<BackpackObject> objects)
        {
            foreach (var obj in objects)
            {
                double currentVolume = GetBackpackVolume();
                if (currentVolume + obj.GetVolume() > Volume)
                {
                    throw new InvalidOperationException($"Backpack is full: cannot add object '{obj.Name}'");
                }
                Objects.Add(obj);
                Weight += obj.Weight;
                ObjectAdded?.Invoke(obj);
            }
        }
        private double GetBackpackVolume()
        {
            double currentVolume = 0.0;
            foreach (var obj in Objects)
            {
                currentVolume += obj.GetVolume();
            }
            return currentVolume;
        }
        private void OnObjectAdded(BackpackObject obj)
        {
            Console.WriteLine($"{obj.Name} added to the backpack");
            Console.WriteLine();
        }
        public void OutputInfo()
        {
            Console.WriteLine($"Backpack Info:");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Fabric: {Fabric}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Volume: {Volume}");
            Console.WriteLine($"{Objects.Count} objects in the backpack:");

            foreach (var obj in Objects)
            {
                Console.WriteLine($"{obj.Name}: (weight: {obj.Weight}, volume: {obj.GetVolume()})");
            }
            Console.WriteLine();
        }
    }
    public class BackpackObject
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }
        private double Volume { get; set; }

        public BackpackObject()
        {
            Name = string.Empty;
            Weight = 0.0;
            Volume = 0.0;
        }
        public BackpackObject(string name, double weight, double volume)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
        }
        public double GetVolume()
        {
            return Volume;
        }
    }
}