using System;

#region software_information
// Title: Pomodoro Timer
// Description: A simple command-line driven timer especially designed for the pomodoro technique.
// Author: Noah Fogarty
// Created: 23-Nov-2022

string version = "rw-1.0.0";
#endregion

#region variables
Pomodoro workTimer;
Pomodoro breakTimer;

int cycleAmount;
#endregion

#region console_output

#region welcome_message
Console.Clear();
Console.Title = "Pomodoro - Hello! ^-^";

Console.WriteLine($"Pomodoro Timer - Version {version}");

Console.Write("\nPress any key to begin configuration...");
Console.ReadKey(true);
#endregion

do
{
    #region configuration
    if (Configuration.UseDefaultValues())
    {
        workTimer = new Pomodoro(25, TimerType.Work);
        breakTimer = new Pomodoro(5, TimerType.Break);
        cycleAmount = 4;
        workTimer.ShouldWait = Configuration.ShouldWait();
        breakTimer.ShouldWait = workTimer.ShouldWait;
    }

    else
    {
        workTimer = Configuration.TimerSetup(TimerType.Work);
        breakTimer = Configuration.TimerSetup(TimerType.Break);
        cycleAmount = Configuration.CycleAmount();
        workTimer.ShouldWait = Configuration.ShouldWait();
        breakTimer.ShouldWait = workTimer.ShouldWait;
    }
    #endregion

    #region main_timer
    do
    {
        int cyclesCompleted = 0;
        while (cyclesCompleted != cycleAmount)
        {
            workTimer.Timer();
            breakTimer.Timer();
            cyclesCompleted++;
        }
    } while (Configuration.RepeatSame());
    #endregion
    
} while (Configuration.RepeatDifferent());

#region goodbye_message
Console.Clear();
Console.Title = "Pomodoro - Goodbye... ;-;";

Console.WriteLine("Thank you for using me!");
Console.Write("\nPress any key to exit...");
Console.ReadKey(true);
#endregion

#endregion