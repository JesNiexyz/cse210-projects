public class EternalGoal : Goal
{
    public EternalGoal(string task, string desc, int points) 
        : base(task, desc, points)
    {
        // nothing to initialize but brackets required
    }

    public override int RecordEvent()
    {
        // Always gives points
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal: {_task}, {_desc},{_points}";
    }
}