using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberProject
{
    class Program
    {
        // Main entry point into our program
        static void Main(string[] args)
        {
            new Program().Run();    // Run all program logic
        }

        // Generates a random integer between one and a provided maximum
        int GenerateNumber(int MaxValue)
        {
            Random rnd = new Random();      // Initialize our Random object
            return rnd.Next(MaxValue) + 1; // Get our random number between one and MaxValue
        }

        // Returns 1 for too hight, -1 for too low, and 0 for an exact match
        int EvaluateGuess(int MagicNumber, int Guess)
        {
            if (Guess > MagicNumber)
                return 1;   // Too high
            else if (Guess < MagicNumber)
                return -1;  // Too low
            else
                return 0;   // Exact
        }

        // Display a prompt and return raw user input
        string GetUserInput(string Prompt)
        {
            Console.WriteLine(Prompt);  // Display prompt
            return Console.ReadLine();  // Return input
        }

        // Contains game logic for a single game
        void RunGame()
        {
            // Greet our user
            Console.WriteLine("Welcome to the Magic Number Game!\n");

            // Get user input and try to parse it as an integer value
            int i = int.Parse(GetUserInput("What is the highest number we can use?"));
            Console.Clear();    // clear screen for cleaner look

            // Generate number
            int MagicNumber = GenerateNumber(i);
            Console.WriteLine($"I have thought of a number between 1 and {i}.");

            // Start the game!
            bool Won = false;           // Have we won yet?
            int Guess = 0;              // Current guess
            int RemainingGuesses = 7;   // How many more guesses do we get?
            int Result = 0;             // Too high, low, or correct

            do     // Play the game
            {
                if (RemainingGuesses < 1)
                {
                    Console.WriteLine("Sorry, no more guesses.");
                    break;
                }

                // Take a guess and convert it into an integer
                Guess = int.Parse(GetUserInput("Take a guess."));
                RemainingGuesses--;

                Result = EvaluateGuess(MagicNumber, Guess);

                switch (Result)     // Tell the user how he did
                {
                    case -1:        // Too low
                        Console.WriteLine($"Too low! Only {RemainingGuesses} guesses remaining.");
                        break;
                    case 1:         // Too high
                        Console.WriteLine($"Too high! Only {RemainingGuesses} guesses remaining.");
                        break;
                    case 0:         // We've won; let's end the game
                        Console.WriteLine("Right on the money!");
                        Won = true;
                        break;
                    default:        // Something went wrong
                        Console.WriteLine("Error! Invalid Result.");
                        break;
                }
            } while (!Won);     // Until we've won

            Console.WriteLine($"Game over! The magic number was {MagicNumber}.");
        }

        // Runs main application logic
        void Run()
        {
            bool Play = true;   // Do we keep playing?
            string UserInput;   // What the user types in to the console

            while(Play)         // As long as we're playing: run the game once and ask if we'd like to go again
            {
                RunGame();      // Run our game
                
                while (true)    // Do this until we hit a break
                {
                    // Prompt for and grab user input
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    UserInput = Console.ReadLine();
                    UserInput = UserInput.ToLower();

                    // Did user input start with 'y'?
                    if (UserInput[0] == 'y')
                    {
                        Play = true;            // Let's play again
                        //InputLoop = false;
                        Console.Clear();        // Clear the screen
                        break;                  // Stop asking for input
                    }
                    // Did user input start with 'n'?
                    else if (UserInput[0] == 'n')
                    {
                        Play = false;           // Stop playing
                        //InputLoop = false;
                        Console.Clear();        // Clear the screen
                        break;                  // Stop asking for input
                    }
                    // User entered something that didn't start with 'y' or 'n'
                    else
                    {
                        //InputLoop = true;
                        Console.Clear();                        // Clear the screen
                        Console.WriteLine("Invalid input.");    // Call the user an idiot
                    }
                }
            }   // End of game loop

            // Have a nice day!
            Console.WriteLine("Thanks for playing!");
        }   // End of Run() function
    }   // End of Program class
}   // End of GuessTheNumberProject namespace
