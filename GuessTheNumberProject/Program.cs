using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberProject
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        int GenerateNumber(int MaxValue)
        {
            Random rnd = new Random();
            int i = rnd.Next(MaxValue) + 1;
            return i;
        }

        int EvaluateGuess(int MagicNumber, int Guess)
        {
            int answer = 0;

            if (Guess > MagicNumber)
                return 1;
            else if (Guess < MagicNumber)
                return -1;
            else
                return 0;
        }

        void Run()
        {
            // Greet our user
            Console.WriteLine("Welcome to the Magic Number Game!\n");
            Console.WriteLine("What is the highest number we can use?");

            // Get user input and try to parse it as an integer value
            string UserInput = Console.ReadLine();
            int i = int.Parse(UserInput);

            // Generate number
            int MagicNumber = GenerateNumber(i);
            Console.WriteLine($"I have thought of a number between 1 and {i}.");

            // Start the game!
            bool Won = false;       // Have we won yet?
            int Guess = 0;
            int Result = 0;

            do     // Play the game
            {
                Console.WriteLine("Take a guess.");
                UserInput = Console.ReadLine();
                Guess = int.Parse(UserInput);

                Result = EvaluateGuess(MagicNumber, Guess);

                switch (Result)     // Tell the user how he did
                {
                    case -1:
                        Console.WriteLine("Too low!");
                        break;
                    case 1:
                        Console.WriteLine("Too high!");
                        break;
                    case 0:         // We've won; let's end the game
                        Console.WriteLine("Right on the money!");
                        Won = true;
                        break;
                    default:
                        Console.WriteLine("Error! Invalid Result.");
                        break;
                }
            } while (!Won);     // Until we've won

            Console.WriteLine($"Congratulations, the magic number was {MagicNumber}. You won!");
        }
    }
}
