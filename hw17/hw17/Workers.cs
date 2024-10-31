using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHouse
{
    public class Worker : IWorker
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Worker(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void ReportBuilt(IPart part)
        {
            Console.WriteLine($"{FirstName} {LastName} built a {part.PartName}.");
        }

        public bool CheckAndBuildPart(House house, IPart part)
        {
            if (!part.IsBuilt)
            {
                part.IsBuilt = true;
                ReportBuilt(part);
                return true;
            }
            return false;
        }

        public void Work(House house)
        {
            if (CheckAndBuildPart(house, house.Basement)) return;

            foreach (var wall in house.Walls)
            {
                if (CheckAndBuildPart(house, wall)) return;
            }

            foreach (var window in house.Windows)
            {
                if (CheckAndBuildPart(house, window)) return;
            }

            if (CheckAndBuildPart(house, house.Door)) return;
            CheckAndBuildPart(house, house.Roof);
        }
    }

    public class TeamLeader : IWorker
    {
        public string FirstName { get; }
        public string LastName { get; }

        public TeamLeader(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public static double CalculateProgress(House house)
        {
            int partsBuilt = house.Parts.Count(part => part.IsBuilt);
            return (partsBuilt / (double)house.TotalParts) * 100;
        }
        public void Work(House house)
        {
            int partsBuilt = 0;

            foreach (var part in house.Parts)
            {
                if (part.IsBuilt)
                {
                    partsBuilt++;
                }
            }
            double progressPercentage = CalculateProgress(house);
            Console.WriteLine($"TeamLeader {FirstName} {LastName} reports: {partsBuilt} out of {house.TotalParts} parts built. Progress: {progressPercentage:F2}%");
        }
    }

}
