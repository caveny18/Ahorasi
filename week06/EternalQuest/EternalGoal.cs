class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points; // never completes

    public override string GetStatusString() => "Eternal (no completion)";

    public override string ToCsv()
        => $"Eternal|{_name}|{_description}|{_points}";
}
