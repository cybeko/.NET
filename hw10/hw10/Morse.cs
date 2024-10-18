using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    namespace Morse
    {
        internal class Morse
        {
            private static readonly string[,] morseCodeArray = new string[,]
            {
            { ".-", "A" },{ "-...", "B" },{ "-.-.", "C" },{ "-..", "D" },
            { ".", "E" },{ "..-.", "F" },{ "--.", "G" },{ "....", "H" },
            { "..", "I" },{ ".---", "J" },{ "-.-", "K" },{ ".-..", "L" },
            { "--", "M" },{ "-.", "N" },{ "---", "O" },{ ".--.", "P" },
            { "--.-", "Q" },{ ".-.", "R" },{ "...", "S" },{ "-", "T" },
            { "..-", "U" },{ "...-", "V" }, { ".--", "W" },{ "-..-", "X" },
            { "-.--", "Y" }, { "--..", "Z" },
            };

            public string Input { get; set; }

            public Morse(string input)
            {
                Input = input;
            }

            public string Encode()
            {
                string morseCode = "";

                foreach (char c in Input.ToUpper())
                {
                    for (int i = 0; i < morseCodeArray.GetLength(0); i++)
                    {
                        if (morseCodeArray[i, 1][0] == c)
                        {
                            morseCode += morseCodeArray[i, 0] + " ";
                            break;
                        }
                    }
                }

                return morseCode.Trim();
            }

            public string Decode()
            {
                string[] morseChars = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string decipheredText = "";

                foreach (string morseChar in morseChars)
                {
                    for (int i = 0; i < morseCodeArray.GetLength(0); i++)
                    {
                        if (morseCodeArray[i, 0] == morseChar)
                        {
                            decipheredText += morseCodeArray[i, 1];
                            break;
                        }
                    }
                }

                return decipheredText;
            }


            public void InputData()
            {
                Console.WriteLine("1. Encode text \n2. Decode Morse");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Enter text:");
                    string input = Console.ReadLine();

                    Morse morse = new Morse(input);
                    string morseCode = morse.Encode();

                    Console.WriteLine($"Morse code: {morseCode}");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter Morse code:");
                    string input = Console.ReadLine();

                    Morse morse = new Morse(input);
                    string text = morse.Decode();

                    Console.WriteLine($"Deciphered text: {text}");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

    }

}
