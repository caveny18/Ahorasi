using System;

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Lap length: 50 meters; miles = meters / 1609.344
    // Spec allows: miles = laps * 50 / 1000 * 0.62 (approx). We'll use that.
    public override double GetDistance()
    {
        double km = (_laps * 50.0) / 1000.0; // kilometers
        double miles = km * 0.62;
        return miles;
    }

    public override double GetSpeed()
    {
        double miles = GetDistance();
        return miles <= 0 ? 0 : (miles / Minutes) * 60.0; // mph
    }

    public override double GetPace()
    {
        double miles = GetDistance();
        return miles <= 0 ? 0 : Minutes / miles; // min per mile
    }
}
