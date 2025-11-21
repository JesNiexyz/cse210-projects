using System; 

public class Goal
{
    public string _task;
    public string _desc;
    public int _points;
    public int _totalScore;

    public Goal (string task, string desc, int points)
    {
        _task = task;
        _desc = desc;
        _points = points;

    }
    //Virtual method to override derrived classes
    public virtual int RecordEvent()
    {
        // Return points earned at a base level
        return _points;
    }
    //Virtual Method to check if goal is complete
    public virtual bool IsComplete()
    {
        return false;
    }


    // Display goal in the list
    public virtual void DisplayGoal()
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
        Console.WriteLine($"{_checkbox} {_task} \n {_desc}");
    }

    // Display detials of each goal
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"{_task}:\n {_desc} - {_points}");
    }

    //Serialize to string for saving
    public virtual string GetStringRepresentation()
    {
        return $"Goal:{_task},{_desc},{_points}";
    }

    //Getter functions
    public string GetTask() => _task;
    public int GetPoints() => _points;

    
}

