using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create at least one activity of each type
        var activities = new List<Activity>
        {
            new Running(new DateTime(2025, 8, 10), minutes: 30, distanceMiles: 3.0),
            new Cycling(new DateTime(2025, 8, 11), minutes: 40, speedMph: 18.5),
            new Swimming(new DateTime(2025, 8, 12), minutes: 25, laps: 32)
        };

        // Iterate and print polymorphic summaries
        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }

        // Keep console open if running with Ctrl+F5
        Console.WriteLine("\n(Press ENTER to exit)");
        Console.ReadLine();
    }
}
