using Game_Characters;
using System;

class Program
{
    static Wizard Wizard = new Wizard("Gandalf", 100, 20, 10);
    static Wolf Wolf = new Wolf("Fenrir", 1000, 15, 5);

    static void Main()
    {
        Console.WriteLine($"A {Wizard.GetName()} Wizard with {Wizard.GetHealth()} hp, {Wizard.GetAttack()} attack, and {Wizard.GetDefense()} defense ");
        Console.WriteLine($"approaches a {Wolf.GetName()} Wolf with {Wolf.GetHealth()} hp, {Wolf.GetAttack()} attack, and {Wolf.GetDefense()} defense.");
        Console.WriteLine();
        Console.WriteLine("Type 'stats' to display stats, 'autoplay' to simulate a battle, 'fight' to attack yourself.");
        Console.WriteLine("The Wizard can cast Icebeam, Fireball, Strengthen, Heal and Shield while the Wolf can only attack.");
        Console.WriteLine();

        while (Wizard.GetHealth() > 0 && Wolf.GetHealth() > 0)
        {
            StartGame();
        }
    }

    public static void StartGame()
    {
        string input = Console.ReadLine();
        if (input == "stats")
        {
            Wizard.DisplayStats();
            Wolf.DisplayStats();
        }
        else if (input == "autoplay")
        {
            AutoPlay();
        }
        else if (input == "fight")
        {
            Wizard.PlayerTurn(Wolf);
        }
        else
        {
            Console.WriteLine("Invalid command. Please enter 'stats', 'autoplay', 'fight'.");
        }
    }

    public static void AutoPlay()
    {
        Console.WriteLine("Battle Start!");
        Console.WriteLine();
        while (Wizard.GetHealth() > 0 && Wolf.GetHealth() > 0)
        {
            Wizard.PlayerTurn(Wolf);
            if (Wolf.GetHealth() <= 0) break;
            Wolf.Turn(Wizard);
        }
        Console.WriteLine("Battle End!");
    }
}
