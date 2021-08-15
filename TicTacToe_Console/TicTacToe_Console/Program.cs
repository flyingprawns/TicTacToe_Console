using System;

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
                    Console.WriteLine("========================");
                    Console.WriteLine("Game Board Placeholder");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("========================");
                    Console.WriteLine();
                    Console.WriteLine("Enter any key to return to the main menu.");
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
}//END namespace TicTacToe_Console
