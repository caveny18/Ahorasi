using System;

class Program
{
    static void Main(string[] args)
    {
        // Inicializamos el generador de números aleatorios
        Random randomGenerator = new Random();

        string playAgain = "yes";

        // Bucle para repetir el juego si el usuario quiere
        while (playAgain.ToLower() == "yes")
        {
            // Generar el número mágico aleatorio entre 1 y 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I have chosen a magic number between 1 and 100. Try to guess it!");

            // Bucle para que el usuario adivine hasta acertar
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Preguntar al usuario si quiere volver a jugar
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing. Goodbye!");
    }
}
