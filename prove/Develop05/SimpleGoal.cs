using System;
public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string task, string desc, int points) : base(task, desc, points)
    {
        _isComplete = false;
    }

    // Constructor for loading file
    public SimpleGoal(string name, string description, int points, bool isComplete) 
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0; //already complete, no points
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_task},{_desc},{_points},{_isComplete}";
    }
}