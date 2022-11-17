
#region software_information
// Title: Pomodoro Timer
// Description: A simple command-line driven timer especially designed for the pomodoro technique.
// Author: Noah Fogarty
// Created: 13-Nov-2022
string version = "1.1.2";

Console.Title = "Pomodoro Timer";

#region changelog
// KNOWN BUGS:
// 1. When user inputs a fractional value when asked how many times the timer should repeat an unhandled exception is thrown.

// CHANGELOG: v1.1.2
// Added: Option to repeat timer with different settings.
// Bugfix: Made it so you can't specify a value of 0 or below for some configuration settings.

// CHANGELOG: v1.1.0 
// Added: Option to have the program ask user to press a key before beginning each timer. User can toggle this option during the initial configuration phase.
// Changed: Cleaned up some code a little bit. | Removed an unnecessary variable and made certain parts of the code more uniform with each other, while also shaving off a few unnecessary lines.
#endregion
#endregion

#region variables
int workMinutes = 25;
int breakMinutes = 5;
int minutesWorked = workMinutes;
int secondCounter = 0;
int repeatAmount = 4;
int amountRepeated = 0;
string userConfigChoice = "Yes";
bool invalidCheckPassed = false;
bool shouldRepeat = true;
bool shouldWait = false;
bool repeatConfig = true;
#endregion

#region welcome_message
Console.Title = "Pomodoro - Hello! ^-^";

Console.WriteLine($"Pomodoro Timer - Version {version}");

Console.Write("Press any key to begin configuration...");
Console.ReadKey(true);
#endregion

#region practical_program
while (repeatConfig)
{
    #region user_configuration
    Console.Clear();
    Console.Title = "Pomodoro - Configuration...";

    Console.WriteLine("Would you like to use the traditional Pomodoro values?");
    Console.Write("Y/N?: ");

    invalidCheckPassed = false;
    while (!invalidCheckPassed)
    {
        userConfigChoice = Console.ReadLine();
        
        switch (userConfigChoice)
        {
            case "Yes":
            case "yes":
            case "Y":
            case "y":
                workMinutes = 25;
                breakMinutes = 5;
                repeatAmount = 4;
                invalidCheckPassed = true;
                break;

            case "No":
            case "no":
            case "N":
            case "n":
                Console.Write("\nHow many minutes would you like each work session to be?: ");
                workMinutes = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nHow many minutes would you like each break session to be?: ");
                breakMinutes = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nHow many times would you like to repeat?: ");
                repeatAmount = Convert.ToInt32(Console.ReadLine());
                invalidCheckPassed = true;
                break;

            default:
                Console.Write("Invalid answer, try again: ");
                break;
        }
    }

    // Asks user whether they should be prompted to press a key before starting each timer.
    Console.Clear();
    Console.Title = "Pomodoro - Configuration...";
    
    Console.WriteLine("Would you like to be prompted before each timer starts?");
    Console.Write("Y/N?: ");

    invalidCheckPassed = false;
    while (!invalidCheckPassed)
    {
        userConfigChoice = Console.ReadLine();
        switch (userConfigChoice)
        {
           case "Yes":
           case "yes": 
           case "Y":
           case "y":
               shouldWait = true;
               invalidCheckPassed = true;
               break;
           
           case "No":
           case "no":
           case "N":
           case "n":
               shouldWait = false;
               invalidCheckPassed = true;
               break;
           
           default:
               Console.Write("Invalid answer, try again: ");
               break;
        }
    }
    #endregion

    #region main_logic
    shouldRepeat = true;
    while (shouldRepeat)
    {
        invalidCheckPassed = false;

        #region timer

        while (amountRepeated != repeatAmount)
        {
            minutesWorked = workMinutes;
            
            if (shouldWait)
            {
                Console.Clear();
                Console.Title = "Pomodoro - Waiting...";
                
                Console.Write("Press any key to start the timer...");
                Console.ReadKey(true);
            }

            Console.Clear();
            Console.Title = "Pomodoro - Working...";
            
            // Work timer.
            while (minutesWorked >= 0)
            {
                if (minutesWorked == 1 && secondCounter == 1) 
                    Console.Write($"\r{minutesWorked} minute and {secondCounter} second left.     ");
                else if (minutesWorked == 1) 
                    Console.Write($"\r{minutesWorked} minute and {secondCounter} seconds left.     ");
                else if (secondCounter == 1) 
                    Console.Write($"\r{minutesWorked} minutes and {secondCounter} second left.     ");
                else 
                    Console.Write($"\r{minutesWorked} minutes and {secondCounter} seconds left.     ");
                if (secondCounter == 0)
                {
                    secondCounter = 60;
                    minutesWorked--;
                }
                Thread.Sleep(1000);
                secondCounter--;
            }

            Console.Beep(440, 1000);

            secondCounter = 0;

            if (shouldWait)
            {
                Console.Clear();
                Console.Title = "Pomodoro - Waiting...";
                
                Console.Write("Press any key to start the timer...");
                Console.ReadKey(true);
            }

            Console.Clear();
            Console.Title = "Pomodoro - Resting...";
            
            // Break timer.
            minutesWorked = breakMinutes;
            while (minutesWorked >= 0)
            {
                if (minutesWorked == 1 && secondCounter == 1) 
                    Console.Write($"\r{minutesWorked} minute and {secondCounter} second left.     ");
                else if (minutesWorked == 1) 
                    Console.Write($"\r{minutesWorked} minute and {secondCounter} seconds left.     ");
                else if (secondCounter == 1) 
                    Console.Write($"\r{minutesWorked} minutes and {secondCounter} second left.     ");
                else 
                    Console.Write($"\r{minutesWorked} minutes and {secondCounter} seconds left.     ");
                if (secondCounter == 0)
                {
                    secondCounter = 60;
                    minutesWorked--;
                }
                Thread.Sleep(1000);
                secondCounter--;
            }
            
            Console.Beep(220, 1000);

            secondCounter = 0;
            
            amountRepeated++;
        }

        amountRepeated = 0;
        #endregion

        #region repeat_question_current
        Console.Clear();
        Console.Title = "Pomodoro - Repeat?";
        
        Console.WriteLine("Would you like to repeat with the current settings?");
        Console.Write("Y/N?: ");

        invalidCheckPassed = false;
        while (!invalidCheckPassed)
        {
            userConfigChoice = Console.ReadLine();

            switch (userConfigChoice)
            {
                case "Yes":
                case "yes":
                case "Y":
                case "y":
                    shouldRepeat = true;
                    invalidCheckPassed = true;
                    break;
                
                case "No":
                case "no":
                case "N":
                case "n":
                    shouldRepeat = false;
                    invalidCheckPassed = true;
                    break;
                
                default:
                    Console.Write("Invalid answer, try again: ");
                    break;
            }
        }
        #endregion
        
        #region repeat_question_different
        if (!shouldRepeat)
        {
            Console.Clear();
            Console.Title = "Pomodoro - Repeat?";
            
            Console.WriteLine("Would you like to repeat with different settings?");
            Console.Write("Y/N?: ");

            invalidCheckPassed = false;
            while (!invalidCheckPassed)
            {
                userConfigChoice = Console.ReadLine();

                switch (userConfigChoice)
                {
                    case "Yes":
                    case "yes": 
                    case "Y":
                    case "y":
                        repeatConfig = true;
                        invalidCheckPassed = true;
                        break;
                    
                    case "No":
                    case "no": 
                    case "N":
                    case "n":
                        repeatConfig = false;
                        invalidCheckPassed = true;
                        break;
                    
                    default:
                        Console.Write("Invalid answer, try again: ");
                        break;
                }
            }
        }
        #endregion
    }
    #endregion
}
#endregion

#region exit_program
Console.Clear();
Console.Title = "Pomodoro - Goodbye... ;-;";

Console.Write("Thank you for using me!");
Console.Write("\n\nPress any key to exit...");

Console.ReadKey(true);
#endregion
