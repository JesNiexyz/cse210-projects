// Timed Goal - user records events within a specific timeframe (in seconds)
public class TimedGoal : Goal
{
    private int _durationInSeconds;
    private DateTime _startTime;
    private int _timesCompleted;

    public TimedGoal(string name, string description, int points, int durationInSeconds) 
        : base(name, description, points)
    {
        _durationInSeconds = durationInSeconds;
        _startTime = DateTime.Now;
        _timesCompleted = 0;
    }

    // Constructor for loading from file
    public TimedGoal(string name, string description, int points, int durationInSeconds, DateTime startTime, int timesCompleted) 
        : base(name, description, points)
    {
        _durationInSeconds = durationInSeconds;
        _startTime = startTime;
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _timesCompleted++;
            return _points;
        }
        return 0; // Time is up
    }

    public override bool IsComplete()
    {
        DateTime endTime = _startTime.AddSeconds(_durationInSeconds);
        return DateTime.Now >= endTime;
    }

    public override void DisplayGoal()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        DateTime endTime = _startTime.AddSeconds(_durationInSeconds);
        TimeSpan remainingTime = endTime - DateTime.Now;
        
        if (remainingTime.TotalSeconds > 0)
        {
            Console.WriteLine($"{checkbox} {_task} ({_desc}) -- Completed: {_timesCompleted} times (Time remaining: {(int)remainingTime.TotalSeconds}s)");
        }
        else
        {
            Console.WriteLine($"{checkbox} {_task} ({_desc}) -- Completed: {_timesCompleted} times (Time's up!)");
        }
    }

    public override void DisplayDetails()
    {
        DateTime endTime = _startTime.AddSeconds(_durationInSeconds);
        TimeSpan remainingTime = endTime - DateTime.Now;
        Console.WriteLine($"{_task}: {_desc} - {_durationInSeconds}s goal, {_points} points per completion. Times completed: {_timesCompleted}");
    }

    public override string GetStringRepresentation()
    {
        return $"TimedGoal:{_task},{_desc},{_points},{_durationInSeconds},{_startTime:O},{_timesCompleted}";
    }
}