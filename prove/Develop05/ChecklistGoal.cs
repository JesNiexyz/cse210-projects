public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    

    public ChecklistGoal(string task, string desc, int points, int target, int bonus)
            : base(task, desc, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

     // Constructor for loading from file
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;

            // If we completed goal add bonus
            if (_amountCompleted == _target)
            {
                return _points + _bonus;
            }
            return _points;
        }
        return 0; //Already fully complete

    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    //Display the goal in the list
   // Then in ChecklistGoal
public override void DisplayGoal()
{
    string _checkbox;
    if (IsComplete())
    {
        _checkbox = "[X]";
    }
    else
    {
        _checkbox = "[ ]";
    }
    Console.WriteLine($"{_checkbox} {_task} ({_desc}) -- Currently completed: {_amountCompleted}/{_target}");

}

    public override void  DisplayDetails()
    {
        Console.WriteLine( $"{_task}: {_desc} - {_points} points each, {_bonus} bonus for completing {_target} times");
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_task},{_desc},{_points},{_bonus},{_target},{_amountCompleted}";
    }

}