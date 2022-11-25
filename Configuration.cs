static class Configuration
{
    static public bool UseDefaultValues()
    {
        while (true)
        {
            Console.Title = "Pomodoro - Configuration";
            Console.Clear();
            
            Console.WriteLine("Would you like to use the default Pomodoro values?");
            Console.Write("Y/N: ");
            string userChoice = Console.ReadLine();
            return YesNo(userChoice);
        }
    }

    static public bool ShouldWait()
    {
        while (true)
        {
            Console.Title = "Pomodoro - Configuration";
            Console.Clear();
            
            Console.WriteLine("Should each cycle wait for your input before starting? ");
            Console.Write("Y/N: ");
            string userChoice = Console.ReadLine();
            return YesNo(userChoice);
        }
    }

    static public int CycleAmount()
    {
        while (true)
        {
            Console.Title = "Pomodoro - Configuration";
            Console.Clear();
            
            Console.Write("How many cycles should there be? ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice < 1) continue;
            else return userChoice;
        }
    }

    static public bool RepeatSame()
    {
        Console.Title = "Pomodoro - Repeat?";
        Console.Clear();
        
        Console.WriteLine("Would you like to repeat the timer with the same settings?");
        Console.Write("Y/N: ");
        string userChoice = Console.ReadLine();

        return YesNo(userChoice);
    }

    static public bool RepeatDifferent()
    {
        Console.Title = "Pomodoro - Repeat?";
        Console.Clear();
        
        Console.WriteLine("Would you like to repeat the timer with different settings?");
        Console.Write("Y/N: ");
        string userChoice = Console.ReadLine();

        return YesNo(userChoice);
    }

    static public Pomodoro TimerSetup(TimerType timerType)
    {
        Console.Title = "Pomodoro - Configuration";
        Console.Clear();
        
        Console.Write($"How many minutes should the {timerType} timer be? ");
        int minutes = Convert.ToInt32(Console.ReadLine());

        return new Pomodoro(minutes, timerType);
    }

    static private bool YesNo(string userChoice)
    {
        while (true)
        {
            Console.Clear();
            
            switch (userChoice)
            {
                case "Yes":
                case "yes":
                case "Y":
                case "y":
                    return true;
                case "No":
                case "no":
                case "N":
                case "n":
                    return false;
                default:
                    Console.Write("Invalid choice: ");
                    userChoice = Console.ReadLine();
                    break;
            }
        }
    }
}