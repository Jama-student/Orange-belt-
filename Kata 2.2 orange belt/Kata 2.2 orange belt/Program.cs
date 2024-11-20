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


    public delegate void CharacterAction();

    
    public event EventHandler HealthChanged;

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    
    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");

        
        target.Health -= 20;

        
        OnHealthChanged(target);
    }

    
    protected virtual void OnHealthChanged(Character target)
    {
        
        HealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
