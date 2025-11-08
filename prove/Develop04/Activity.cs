public class Activity
{
    public Timer _timer;

    public string _name;
    public string _description;
    public int _duration;
    protected DateTime _endTime;
    private Thread _countdownThread;
    private bool _activityRunning;

    public Activity(string name, string description)
    {


        _name = name;
        _description = description; 
        _timer = new Timer();
    }

    public void DisplayStart()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}. \n");
        Console.WriteLine($"{_description} \n");
        Console.WriteLine($"Write the activity length in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        _timer.DisplaySpinner();
        Console.Clear();

        // Set the end time for the activity
        _endTime = DateTime.Now.AddSeconds(_duration);

        //Start the countdown display thread
        StartCountDownDisplay();

    }

    public void DisplayEnd()
    {
        //Stop countdown thread
        StopCountdownDisplay();

        Console.WriteLine("\n Completed!");
        _timer.DisplaySpinner();
        Console.WriteLine($"The {_name} was completed in {_duration} seconds");
        _timer.DisplaySpinner();
    }

    //Start background to update timer constantly
    protected void StartCountDownDisplay()
    {
        _activityRunning = true;
        _countdownThread = new Thread(() =>
        {
            while (_activityRunning && DateTime.Now < _endTime)
            {
                TimeSpan remaining = _endTime - DateTime.Now;
                int secondsLeft = Math.Max(0, (int)remaining.TotalSeconds);

                int savedLeft = Console.CursorLeft;
                int savedTop = Console.CursorTop;

                try
                {
                    //Move to top line (line 0)
                    Console.SetCursorPosition(0, 0);

                    //Clear the first line
                    Console.Write(new string(' ', Console.WindowWidth - 1));
                    Console.SetCursorPosition(0, 0);

                    // Write Countdown
                    Console.Write($"Time Remaining: {secondsLeft} seconds");

                    if (savedTop > 0 && savedTop < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(savedLeft, savedTop);
                    }
                }
                catch
                {

                }

                // //Move to the top of the line
                // Console.SetCursorPosition(0, 0);
                // Console.Write(new string(' ', Console.WindowWidth));
                // Console.SetCursorPosition(0, 0);
                // Console.Write($"Time Remaining: {secondsLeft} seconds");

                Thread.Sleep(1000); //Updates every second
            }

            try
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 0);
                Console.Write($"Time's up");
            }
            catch
            {
                //ignore cursor erros
            }
            
            

            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);
            Console.Write($"Time's up");
        });
        _countdownThread.IsBackground = true;
        _countdownThread.Start();
    }

    //Stop countdown thread
    protected void StopCountdownDisplay()
    {
        _activityRunning = false;
        if (_countdownThread != null && _countdownThread.IsAlive)
        {
            _countdownThread.Join(100); //Wait until thread is finished
        }
    }
    
    protected bool IsTimeUp()
    {
        return DateTime.Now >= _endTime;
    }
}