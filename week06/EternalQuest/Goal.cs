using System;
using System.IO;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;

    // Polymorphic API
    public abstract int RecordEvent(); // returns points earned

    public virtual string GetDetailsString()
        => $"[ ] {_name} ({_description})";

    public abstract string GetStatusString();

    // Persistence helpers
    public abstract string ToCsv();

    public static Goal FromCsv(string line)
    {
        // type|name|description|points|...
        var parts = line.Split('|');
        string type = parts[0];

        return type switch
        {
            "Simple"    => new SimpleGoal(
                              parts[1], parts[2], int.Parse(parts[3]),
                              bool.Parse(parts[4])),
            "Eternal"   => new EternalGoal(
                              parts[1], parts[2], int.Parse(parts[3])),
            "Checklist" => new ChecklistGoal(
                              parts[1], parts[2], int.Parse(parts[3]),
                              int.Parse(parts[4]), int.Parse(parts[5]),
                              int.Parse(parts[6])),
            _ => throw new InvalidDataException("Unknown goal type: " + type),
        };
    }
}
