namespace Level_1_Striped_Yellow_Belt;

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a Warrior and a Healer with health values
        Character warrior = new Character("Warrior", 40);
        Character healer = new Character("Healer", 60);

        // Assign Actions to characters using lambdas
        warrior.PrimaryAction = () => Console.WriteLine("Warrior attacks the enemy!");
        healer.PrimaryAction = () => Console.WriteLine("Healer casts Heal!");

        // Check health and invoke the appropriate action
        // Warrior attacks if health is below 50
        if (warrior.Health < 50)
        {
            warrior.PrimaryAction.Invoke();
        }

        // Healer heals if health is below 50 or prioritizes healing another character
        if (healer.Health < 50)
        {
            healer.PrimaryAction.Invoke();
        }
        else
        {
            // Healer will heal the warrior since his health is below 50
            healer.PrimaryAction = () => Console.WriteLine("Healer heals Warrior!");
            healer.PrimaryAction.Invoke();
        }
    }
}

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Action PrimaryAction { get; set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
}