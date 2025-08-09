using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private readonly List<Goal> _goals = new();
    private int _score = 0;

    // Tiny gamification: every 1000 pts -> level up
    public int Level => 1 + _score / 1000;

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine($"Score: {_score}   |   Level: {Level}\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoals(); break;
                    case "3": RecordEvent(); break;
                    case "4": SaveGoals(); break;
                    case "5": LoadGoals(); break;
                    case "6": return;
                    default:  break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Create New Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose type: ");
        string? type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";
        Console.Write("Points per completion: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine() ?? "1");
                Console.Write("Bonus on completion: ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid type.");
                Console.ReadLine();
                return;
        }

        Console.WriteLine("Goal created! Press ENTER to continue...");
        Console.ReadLine();
    }

    private void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("Your Goals\n");
        if (_goals.Count == 0)
        {
            Console.WriteLine("(none yet)");
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadLine();
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet. Press ENTER...");
            Console.ReadLine();
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? (number): ");
        int index = int.Parse(Console.ReadLine() ?? "0") - 1;
        if (index < 0 || index >= _goals.Count) return;

        int gained = _goals[index].RecordEvent();
        _score += gained;

        Console.WriteLine($"\nYou gained {gained} points!");
        Console.WriteLine($"New Score: {_score} | Level: {Level}");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        Console.Write("File name to save (e.g., goals.txt): ");
        string file = Console.ReadLine() ?? "goals.txt";

        using var sw = new StreamWriter(file);
        sw.WriteLine(_score);
        foreach (var g in _goals) sw.WriteLine(g.ToCsv());

        Console.WriteLine("Saved! Press ENTER to continue...");
        Console.ReadLine();
    }

    private void LoadGoals()
    {
        Console.Write("File name to load (e.g., goals.txt): ");
        string file = Console.ReadLine() ?? "goals.txt";
        if (!File.Exists(file)) throw new FileNotFoundException(file);

        _goals.Clear();
        using var sr = new StreamReader(file);
        _score = int.Parse(sr.ReadLine() ?? "0");

        string? line;
        while ((line = sr.ReadLine()) != null)
            _goals.Add(Goal.FromCsv(line));

        Console.WriteLine("Loaded! Press ENTER to continue...");
        Console.ReadLine();
    }
}
