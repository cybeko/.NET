using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw21_generic
{
    public class FootballTeam<T> : IEnumerable<T> where T : FootballPlayer
    {
        public string Name { get; private set; }
        public T[] Players { get; private set; }

        public FootballTeam(int count, string name)
        {
            Players = new T[count];
            Name = name;
        }
        public void PrintAllPlayers()
        {
            Console.WriteLine($"\nTeam: {Name}\n\tInfo: ");
            foreach (var player in this)
            {
                if (player != null)
                {
                    Console.WriteLine($"Team: {player.TeamName}, Name: {player.Name} {player.LastName}, Age: {player.Age}");
                }
            }
        }

        public void AddPlayer(T player)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i] == null)
                {
                    Players[i] = player;
                    player.TeamName = Name;
                    return;
                }
            }
            throw new InvalidOperationException("Cannot add more players. No more space in team.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var player in Players)
            {
                if (player != null)
                {
                    yield return player;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FootballPlayer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TeamName { get; set; }

        public FootballPlayer(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            TeamName = "No Team";
        }
    }
}
