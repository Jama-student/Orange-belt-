namespace Kata_2._2_orange_belt;

using System;

class Program
{
    static void Main(string[] args)
    {
    
        Character warrior = new Character("Warrior", 100);
        Character goblin = new Character("Goblin", 50);

        
        warrior.HealthChanged += (sender, e) => Console.WriteLine($"{warrior.Name}'s health is now {warrior.Health}");
        goblin.HealthChanged += (sender, e) => Console.WriteLine($"{goblin.Name}'s health is now {goblin.Health}");

        
        warrior.Attack(goblin);  

        
    }
}

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }

    // Declare a delegate to represent character actions
    public delegate void CharacterAction();

    // Declare an event to notify when health changes
    public event EventHandler HealthChanged;

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    // Attack method to reduce health of a target character
    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");

        // Reduce target's health
        target.Health -= 20;

        // Trigger the HealthChanged event
        OnHealthChanged(target);
    }

    // Method to trigger the HealthChanged event
    protected virtual void OnHealthChanged(Character target)
    {
        // If there are subscribers, trigger the event
        HealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
