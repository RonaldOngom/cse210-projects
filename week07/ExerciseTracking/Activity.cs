using System;

public abstract class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    // Abstract methods (POLYMORPHISM requirement)
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Base summary method (uses polymorphism correctly)
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_lengthMinutes} min) - " +
               $"Distance {GetDistance():0.0}, Speed {GetSpeed():0.0}, Pace: {GetPace():0.0}";
    }
}