using System;

// Enhancements beyond core requirements:
// - Scripture selection is randomized from a list (multiple verses)
// - Improved user interface with clear instructions
// - Encapsulation is fully applied with private variables and methods

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Scripture scripture = GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit" || scripture.IsCompletelyHidden())
                break;

            scripture.HideRandomWords();
        }

        Console.WriteLine("\nProgram ended. Press ENTER to close.");
        Console.ReadLine();
    }

    static Scripture GetRandomScripture()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy.")
        };

        Random rand = new Random();
        return scriptures[rand.Next(scriptures.Count)];
    }
}
