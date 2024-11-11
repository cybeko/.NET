using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public class Word
    {
        public string English { get; set; }
        public List<string> French { get; set; }

        public Word(string english)
        {
            English = english;
            French = new List<string>();
        }
    }
    public class EnglishFrenchDictionary
    {
        public Dictionary<string, Word> Dictionary { get; private set; } = new Dictionary<string, Word>();
        public EnglishFrenchDictionary()
        {
            Dictionary = new Dictionary<string, Word>();
        }
        public void AddWord(string eng, string fr)
        {
            if (!Dictionary.ContainsKey(eng))
            {
                Dictionary[eng] = new Word(eng);
            }
            Dictionary[eng].French.Add(fr);
        }
        public void AddWord(string eng, params string[] fr)
        {
            if (!Dictionary.ContainsKey(eng))
            {
                Dictionary[eng] = new Word(eng);
            }
            Dictionary[eng].French.AddRange(fr);
        }
        public void RemoveWord(string eng)
        {
            if (Dictionary.ContainsKey(eng))
            {
                Dictionary.Remove(eng);
                Console.WriteLine($"Word '{eng}' removed");
            }
            else
            {
                Console.WriteLine($"Word '{eng}' not found");
            }
        }
        public void RemoveFrenchTranslation(string eng, string fr)
        {
            if (Dictionary.ContainsKey(eng))
            {
                var word = Dictionary[eng];
                if (word.French.Contains(fr))
                {
                    word.French.Remove(fr);
                    Console.WriteLine($"Translation '{fr}' for word '{eng}' removed");
                }
                else
                {
                    Console.WriteLine($"Translation '{fr}' for word '{eng}' not found");
                }
            }
            else
            {
                Console.WriteLine($"Word '{eng}' not found");
            }
        }
        public void ModifyWord(string old_eng, string new_eng)
        {
            if (Dictionary.ContainsKey(old_eng))
            {
                var word = Dictionary[old_eng];
                Dictionary.Remove(old_eng);
                word.English = new_eng;
                Dictionary[new_eng] = word;
                Console.WriteLine($"Word '{old_eng}' changed to '{new_eng}'.");
            }
            else
            {
                Console.WriteLine($"Word '{old_eng}' not found");
            }
        }
        public void EditFrenchTranslation(string eng, string old_fr, string new_fr)
        {
            if (Dictionary.ContainsKey(eng))
            {
                var word = Dictionary[eng];
                if (word.French.Contains(old_fr))
                {
                    int index = word.French.IndexOf(old_fr);
                    word.French[index] = new_fr;
                    Console.WriteLine($"Translation '{old_fr}' changed to '{new_fr}' for word '{eng}'");
                }
                else
                {
                    Console.WriteLine($"Translation '{old_fr}' fro word '{eng}' not found");
                }
            }
            else
            {
                Console.WriteLine($"Слово '{eng}' не найдено.");
            }
        }
        public void SearchTranslation(string eng)
        {
            if (Dictionary.TryGetValue(eng, out Word? value))
            {
                var word = value;
                Console.WriteLine($"Translations for word '{eng}':");
                foreach (var french in word.French)
                {
                    Console.WriteLine(french);
                }
            }
            else
            {
                Console.WriteLine($"Word '{eng}' not found");
            }
        }
    }
}
