using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    // Attributes shared among all activities
    private DateTime date;
    private int duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    // Abstract methods to be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Summary method
    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} {this.GetType().Name} ({duration} min): " +
               $"Distance: {GetDistance():F1} {GetDistanceUnit()}, " +
               $"Speed: {GetSpeed():F1} {GetSpeedUnit()}, " +
               $"Pace: {GetPace():F2} min per {GetPaceUnit()}";
    }

    protected virtual string GetDistanceUnit() => "miles";
    protected virtual string GetSpeedUnit() => "mph";
    protected virtual string GetPaceUnit() => "mile";
}

// Derived class for Running
public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance) 
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / duration) * 60; // mph

    public override double GetPace() => duration / distance; // min per mile
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int duration, double speed) 
        : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * duration) / 60; // miles

    public override double GetSpeed() => speed; // mph

    public override double GetPace() => 60 / speed; // min per mile
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps; // number of laps

    public Swimming(DateTime date, int duration, int laps) 
        : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50 / 1000.0 * 0.62; // miles

    public override double GetSpeed() => (GetDistance() / duration) * 60; // mph

    public override double GetPace() => duration / GetDistance(); // min per mile

    protected override string GetDistanceUnit() => "miles";
    protected override string GetSpeedUnit() => "mph";
    protected override string GetPaceUnit() => "mile";
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold activities
        List<Activity> activities = new List<Activity>();

        // Add activities
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 12.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 5), 60, 20));

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
