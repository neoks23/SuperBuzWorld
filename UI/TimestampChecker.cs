using Godot;
using System;

public class TimestampChecker : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    public bool IsTimestampValid(string timestamp)
    {
        DateTime t = Convert.ToDateTime(timestamp);
        DateTime n = DateTime.Now;
        TimeSpan span = n.Subtract(t);

        GD.Print("Minutes left: " + span.TotalMinutes.ToString());
        if (span.TotalMinutes < 5)
        {
            return true;
        }
        return false;
    }
}
