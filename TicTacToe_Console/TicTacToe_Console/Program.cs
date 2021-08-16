using System;
using System.Diagnostics;

namespace TicTacToe_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Main Menu
                Console.WriteLine();
                Console.WriteLine("=============");
                Console.WriteLine(" TIC TAC TOE ");
                Console.WriteLine("=============");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Info");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("\nPlease choose an option: ");

                //Get userInput
                string userInput;
                try
                {
                    userInput = Console.ReadLine(); //Note: Using "Console.Read()" can lead to some funny errors, similiar to CIN buffer errors in C++.
                                                    //      Avoid this problem by using "Console.ReadLine()" instead.
                }
                catch(Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error in main menu option select. Message: {0}", e.Message);
                    Console.WriteLine();
                    continue;
                }

                //Act based on userInput
                if(userInput == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Tic-Tac-Toe game is starting! Press 'enter' to acknowledge.");
                    Console.ReadLine();

                    TicTacToe_Board game = new TicTacToe_Board();
                    game.StartGame();

                    Console.WriteLine();
                    Console.WriteLine("Game is over. Press 'enter' to return to main menu.");
                    Console.ReadLine();
                }
                else if (userInput == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Info");
                    Console.WriteLine("-----");
                    Console.WriteLine("This program was written by and is the intellectual property of Jack Qijie Zhu.");
                    Console.WriteLine("-----");
                    Console.WriteLine();
                    Console.WriteLine("Enter any key to return to the main menu.");
                    Console.ReadLine();
                }
                else if (userInput == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine("Exiting Tic-Tac-Toe Game.");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a number that is a menu option.");
                    Console.WriteLine();
                }
            }

            //End Program
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("Program ending, have a nice day!");
            Console.WriteLine("================================");
            return;
        }//END Main()


     }//END class Program

    public class TicTacToe_Board
    {
        // -----
        // Enum
        // -----
        enum Turn
        {
            X = 1, O = 0
        }

        // -------
        // Fields
        // -------
        private char[] squares;
        private Turn turn;

        // -------------
        // Constructors
        // -------------
        public TicTacToe_Board()
        {
            turn = Turn.X;
            squares = new char[9];
            for(int i = 0; i <= 8; i++)
            {
                squares[i] = ' ';
            }
        }

        // --------
        // Methods
        // --------
        private void DisplayBoard()
        {
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine(" {0}  |  {1}  |  {2} ", squares[0], squares[1], squares[2]);
            Console.WriteLine("_____________");
            Console.WriteLine();
            Console.WriteLine(" {0}  |  {1}  |  {2} ", squares[3], squares[4], squares[5]);
            Console.WriteLine("_____________");
            Console.WriteLine();
            Console.WriteLine(" {0}  |  {1}  |  {2} ", squares[6], squares[7], squares[8]);
            Console.WriteLine("=============");
            Console.WriteLine();
        }
        private void PlacePiece(int square)
        {
            Debug.Assert(isValidSquare(square), "Error in TicTacToe_Board.PlacePiece(). Parameter 'square' is invalid.");

            char piece;
            if(turn == Turn.X)
            {
                piece = 'X';
            }
            else if (turn == Turn.O)
            {
                piece = 'O';
            }
            else
            {
                piece = '?';
            }
            squares[square-1] = piece;
        }
        private void NextTurn()
        {
            turn = 1 - turn;
        }
        private bool isValidSquare(int square)
        {
            if(1 <= square && square <= 9 && squares[square-1] == ' ')
            {
                return true;
            }
            return false;
        }
        public void StartGame()
        {
            string userInput;

            // One iteration = one 'turn'
            while (true)
            {
                //Display Game Interface
                Console.WriteLine(" Tic Tac Toe ");
                DisplayBoard();
                Console.WriteLine("The board's squares are numbered from 1-9.");
                Console.WriteLine("Enter a number to place a piece");
                Console.WriteLine("Other commands: 'quit' or 'restart'.");

                //Get and process userInput
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "quit") 
                {
                    break;
                }
                else if (userInput.ToLower() == "restart")
                {
                    ResetGame();
                    continue;
                }

                //Try to convert userInput to integer
                int square;
                try
                {
                    square = Convert.ToInt32(userInput);
                }
                catch(Exception)
                {
                    Console.WriteLine("Please enter a valid square or command. Press 'enter' to try again.");
                    Console.ReadLine();
                    continue;
                }

                //Try to place the piece!
                if (isValidSquare(square))
                {
                    PlacePiece(square);
                    if (GameIsOver() == true)
                    {
                        DisplayBoard();
                        Console.WriteLine();
                        Console.WriteLine("=========================");
                        Console.WriteLine(" {0} has won the game !!!", turn);
                        Console.WriteLine("=========================");
                        break;
                    }
                    NextTurn();
                }
                else
                {
                    Console.WriteLine("Please enter a valid square or command. Press 'enter' to try again.");
                    Console.ReadLine();
                }
            }

            // End Game
            ResetGame();
            Console.WriteLine("Exiting game. Press 'enter' to acknowledge.");
            Console.ReadLine();
        }
        private bool GameIsOver()
        {   
            //Get the side ('X' or 'O') that placed the last piece
            char c = '?';
            if(turn == Turn.O)
            {
                c = 'O';
            }
            else if (turn == Turn.X)
            {
                c = 'X';
            }
            else
            {
                Console.WriteLine("Error in TicTacToe_Board.GameIsOver(). Private field 'turn' is not a valid value.");
                Console.ReadLine();
                return false;
            }

            //Check if that side won
            if(squares[0] == c && squares[1] == c && squares[2] == c)   //horizontal connect 3
            {
                return true;
            }
            if (squares[3] == c && squares[4] == c && squares[5] == c)
            {
                return true;
            }
            if (squares[6] == c && squares[7] == c && squares[8] == c)
            {
                return true;
            }
            if (squares[0] == c && squares[3] == c && squares[6] == c)   //vertical connect 3
            {
                return true;
            }
            if (squares[1] == c && squares[4] == c && squares[7] == c)
            {
                return true;
            }
            if (squares[2] == c && squares[5] == c && squares[8] == c)
            {
                return true;
            }
            if (squares[0] == c && squares[4] == c && squares[8] == c)   //diagonal connect 3
            {
                return true;
            }
            if (squares[2] == c && squares[4] == c && squares[6] == c)
            {
                return true;
            }
            return false;
        }
        private void ResetGame()
        {
            turn = Turn.X;
            squares = new char[9];
            for (int i = 0; i <= 8; i++)
            {
                squares[i] = ' ';
            }
        }
    }
}//END namespace TicTacToe_Console
