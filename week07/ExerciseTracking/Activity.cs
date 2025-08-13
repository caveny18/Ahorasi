using System;
using System.Globalization; // <-- va arriba, junto con los otros using

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;   // read-only (encapsulation)
    public int Minutes  => _minutes; // read-only (encapsulation)

    // Métodos a implementar en derivadas
    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();    // mph
    public abstract double GetPace();     // min per mile

    // Summary compartido (usa los métodos polimórficos)
    public virtual string GetSummary()
    {
        // Fuerza formato en inglés: 03 Nov 2022
        string when = Date.ToString("dd MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));

        string name  = GetType().Name; // Running, Cycling, Swimming
        double dist  = GetDistance();
        double speed = GetSpeed();
        double pace  = GetPace();

        return $"{when} {name} ({Minutes} min): " +
               $"Distance {dist:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
    }
}
