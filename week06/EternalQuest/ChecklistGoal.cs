class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points,
                         int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public bool IsComplete => _currentCount >= _targetCount;

    public override int RecordEvent()
    {
        if (IsComplete) return 0;
        _currentCount++;
        int total = _points;
        if (IsComplete) total += _bonus;
        return total;
    }

    public override string GetDetailsString()
    {
        string box = IsComplete ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStatusString()
        => $"Completed {_currentCount}/{_targetCount}";

    public override string ToCsv()
        => $"Checklist|{_name}|{_description}|{_points}|{_targetCount}|{_bonus}|{_currentCount}";
}
