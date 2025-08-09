using System;

class Program
{
    static void Main()
    {
        var manager = new GoalManager();
        manager.Run();
    }
}

/*
EXCEEDS REQUIREMENTS:
- Added simple gamification: LEVEL = 1 + (Score / 1000).
- Clean CSV save/load for all goal types (score + progress).
- Strong OOP: abstract base + overrides + encapsulation.
*/
