using System;
using System.Threading;

class Pomodoro
{
    #region properties
    public int Minutes { get; set; } = 25;
    public bool WaitForInput { get; set; } = false;
    public TimerType TimerType { get; set; }
    public bool ShouldWait { get; set; } = false;

    #endregion

    #region constructors
    public Pomodoro(int minutes, TimerType timerType, bool shouldWait)
    {
        Minutes = minutes;
        TimerType = timerType;
        ShouldWait = shouldWait;
    }
    
    public Pomodoro(int minutes, TimerType timerType)
    {
        Minutes = minutes;
        TimerType = timerType;
    }

    public Pomodoro(TimerType timerType) => TimerType = timerType;
    #endregion

    #region methods
    public void Timer()
    {
        if (ShouldWait)
        {
            Console.Title = "Pomodoro - Waiting...";
            Console.Clear();

            Console.Write("Press any key continue...");
            Console.ReadKey(true);
        } 
        
        if (TimerType == TimerType.Work) Console.Title = "Pomodoro - Working...";
        else Console.Title = "Pomodoro - Breaking...";
        Console.Clear();

        int minutesWorked = Minutes;
        int secondCounter = 0;

        while (minutesWorked >= 0)
        {
            if (minutesWorked == 1 && secondCounter == 1) Console.Write($"\r{minutesWorked} minute and {secondCounter} second left.          ");
            else if (minutesWorked == 1) Console.Write($"\r{minutesWorked} minute and {secondCounter} seconds left.          ");
            else if (secondCounter == 1) Console.Write($"\r{minutesWorked} minutes and {secondCounter} second left.          ");
            else Console.Write($"\r{minutesWorked} minutes and {secondCounter} seconds left.          ");

            if (secondCounter == 0)
            {
                secondCounter = 60;
                minutesWorked--;
            }

            Thread.Sleep(1000);
            secondCounter--;
        }

        Console.Beep(440, 1000);
    }
    #endregion
}