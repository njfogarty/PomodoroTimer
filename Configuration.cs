static class Configuration
{
    public static bool UseDefaultValues()
    {
        while (true)
        {
            Console.Title = "Pomodoro - Configuration";
            Console.Clear();
            
            Console.WriteLine("Would you like to use the default Pomodoro values?");
            Console.Write("Y/N: ");
            return YesNo(Console.ReadLine());
        }
    }

    public static bool ShouldWait()
    {
        while (true)
        {
            Console.Title = "Pomodoro - Configuration";
            Console.Clear();
            
            Console.WriteLine("Should each cycle wait for your input before starting? ");
            Console.Write("Y/N: ");
            return YesNo(Console.ReadLine());
        }
    }

    public static int CycleAmount()
    {
        int userChoice = 0;
            Console.Title = "Pomodoro - Configuration";
            Console.Clear();

            Console.Write("How many cycles should there be? ");
            string? cycleAnswer = Console.ReadLine();

            while (userChoice < 1)
            {
                while (!int.TryParse(cycleAnswer, out userChoice))
                {
                    Console.Write("Invalid choice, must be a number: ");
                    cycleAnswer = Console.ReadLine();
                }

                while (int.TryParse(cycleAnswer, out userChoice) && userChoice < 1)
                {
                    Console.Write("Invalid choice, must be a number higher than 0: ");
                    cycleAnswer = Console.ReadLine();
                }
            }

            return userChoice;
    }

    public static bool RepeatSame()
    {
        Console.Title = "Pomodoro - Repeat?";
        Console.Clear();
        
        Console.WriteLine("Would you like to repeat the timer with the same settings?");
        Console.Write("Y/N: ");
        return YesNo(Console.ReadLine());
    }

    public static bool RepeatDifferent()
    {
        Console.Title = "Pomodoro - Repeat?";
        Console.Clear();
        
        Console.WriteLine("Would you like to repeat the timer with different settings?");
        Console.Write("Y/N: ");
        return YesNo(Console.ReadLine());
    }

    public static Pomodoro TimerSetup(TimerType timerType)
    {
        int minutes;
        Console.Title = "Pomodoro - Configuration";
        Console.Clear();
        
        Console.Write($"How many minutes should the {timerType} timer be? ");
           
        string? minutesAnswer = Console.ReadLine();
            
        while (!int.TryParse(minutesAnswer, out minutes))
        {
            Console.Write("Invalid option, must be a number: ");
            minutesAnswer = Console.ReadLine();
        }

        return new Pomodoro(minutes, timerType);
    }

    private static bool YesNo(string? userChoice)
    {
        while (true)
        {
            switch (userChoice)
            {
                case "YES":
                case "YEs":
                case "yES":
                case "Yes":
                case "yEs":
                case "yeS":
                case "yes":
                case "Y":
                case "y":
                    return true;
                case "NO":
                case "No":
                case "nO":
                case "no":
                case "N":
                case "n":
                    return false;
                default:
                    Console.Write("Invalid choice, must be a yes or no answer: ");
                    userChoice = Console.ReadLine();
                    break;
            }
        }
    }
}