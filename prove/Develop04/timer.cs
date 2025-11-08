public class Timer
{
    private string _spinner;

    public Timer()
    {
        _spinner = "|/-\\";
    }

    public void DisplaySpinner()
    {
        // default spinner duration: two full cycles (spinner.Length * 2 * 250ms)
        DisplaySpinner(_spinner.Length * 2 * 250);
    }

    // Display spinner for up to the specified milliseconds (honors shorter remaining time)
    public void DisplaySpinner(int milliseconds)
    {
        if (milliseconds <= 0) return;

        int interval = 250; // ms per spinner frame
        int frames = Math.Max(1, milliseconds / interval);

        for (int i = 0; i < frames; i++)
        {
            Console.Write(_spinner[i % _spinner.Length]);
            Thread.Sleep(interval);
            Console.Write("\b \b");
        }
    }

    public void SetTimer(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void DisplayCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.WriteLine($"Time remaining {i} seconds");
            Thread.Sleep(1000);

            //Clear line and display new cursor 
            Console.Write("\r" + new string(' ', 50) + '\r');
        };
    }

    public bool IsTimeUp(DateTime endtime)
    {
        return DateTime.Now >= endtime;
    }
    
    public void ShowRemainingTime (DateTime endTime)
    {
        TimeSpan remaining = endTime - DateTime.Now;
        if (remaining.TotalSeconds > 0)
        {
            Console.Write($" [{(int)remaining.TotalSeconds}s remaining]");
        }
    }

}