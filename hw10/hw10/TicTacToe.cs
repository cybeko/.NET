using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    namespace TicTacToe
    {
        internal class TicTacToe
        {
            private string[,] _matrix = new string[3, 3];
            public string Player1 { get; set; }
            public string Player2 { get; set; }
            private Random _random = new Random();
            public int FilledCells { get; private set; }
            public string[,] Matrix { get => _matrix; }

            public TicTacToe(string player_1, string player_2)
            {
                Player1 = player_1;
                Player2 = player_2;
                PrepareMatrix();
            }

            public void PrepareMatrix()
            {
                int counter = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Matrix[i, j] = counter.ToString();
                        counter++;
                    }
                }
            }

            public void RenderMatrix()
            {
                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Matrix[i, j] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (Matrix[i, j] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.Write($"{Matrix[i, j]}\t");
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }

            public void PlayGame()
            {
                bool isPlayer1Turn = _random.Next(2) == 0;
                bool isWon = false;
                bool _displayErrorMessage = false;

                while (!isWon)
                {
                    RenderMatrix();
                    if (_displayErrorMessage)
                    {
                        Console.WriteLine("Invalid move");
                    }

                    Console.WriteLine(isPlayer1Turn ? $"{Player1}'s Turn (X):" : $"{Player2}'s Turn (O):");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    char key = keyInfo.KeyChar;

                    bool isValidMove = UpdateMatrix(key.ToString(), isPlayer1Turn ? "X" : "O");

                    if (!isValidMove)
                    {
                        _displayErrorMessage = true;
                        continue;
                    }

                    _displayErrorMessage = false;

                    if (FilledCells >= 5)
                    {
                        isWon = CheckWinner(isPlayer1Turn ? "X" : "O");
                        if (isWon)
                        {
                            RenderMatrix();
                            Console.WriteLine(isPlayer1Turn ? $"{Player1} wins" : $"{Player2} wins");
                            break;
                        }
                    }

                    isPlayer1Turn = !isPlayer1Turn;

                    if (IsDraw() && !isWon)
                    {
                        RenderMatrix();
                        Console.WriteLine("It's a draw");
                        break;
                    }
                }
            }

            public bool UpdateMatrix(string input, string symbol)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Matrix[i, j] == input)
                        {
                            Matrix[i, j] = symbol;
                            FilledCells++;
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool IsDraw()
            {
                return FilledCells == 9;
            }

            public bool CheckWinner(string symbol)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Matrix[i, 0] == symbol && Matrix[i, 1] == symbol && Matrix[i, 2] == symbol)
                    {
                        return true;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (Matrix[0, i] == symbol && Matrix[1, i] == symbol && Matrix[2, i] == symbol)
                    {
                        return true;
                    }
                }
                if (Matrix[0, 0] == symbol && Matrix[1, 1] == symbol && Matrix[2, 2] == symbol)
                {
                    return true;
                }

                if (Matrix[0, 2] == symbol && Matrix[1, 1] == symbol && Matrix[2, 0] == symbol)
                {
                    return true;
                }
                return false;
            }
        }
    }

}
