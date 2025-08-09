class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;   // prevent double scoring
        _isComplete = true;
        return _points;
    }

    public override string GetDetailsString()
        => $"{(_isComplete ? "[X]" : "[ ]")} {_name} ({_description})";

    public override string GetStatusString()
        => _isComplete ? "Completed" : "Not completed";

    public override string ToCsv()
        => $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
}
