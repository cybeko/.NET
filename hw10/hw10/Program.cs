using Application.Morse;
using Application.TicTacToe;
using static System.Console;

namespace MainSpace
{
    class Program
    {
        static void Main()
        {
            Morse morse = new Morse("");
            morse.InputData();

            WriteLine("Enter first player's name:");
            string player1 = ReadLine();

            WriteLine("Enter second player's name:");
            string player2 = ReadLine();

            TicTacToe game = new TicTacToe(player1, player2);
            game.PlayGame();
        }
    }
}