using System;

class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance() => _distanceMiles;

    public override double GetSpeed()
        => _distanceMiles <= 0 ? 0 : (_distanceMiles / Minutes) * 60.0;

    public override double GetPace()
        => _distanceMiles <= 0 ? 0 : Minutes / _distanceMiles;
}
