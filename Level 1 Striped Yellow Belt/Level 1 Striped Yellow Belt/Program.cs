namespace Level_1_Striped_Yellow_Belt;

using System;

class Program
{
    static void Main(string[] args)
    {
        Character warrior = new Character("Warrior", 100);
        Character healer = new Character("Healer", 80);

        warrior.HealthChanged += (sender, e) =>
        {
            Console.WriteLine($"{((Character)sender).Name}'s health is now {((Character)sender).Health}");
        };

        healer.HealthChanged += (sender, e) =>
        {
            Console.WriteLine($"{((Character)sender).Name}'s health is now {((Character)sender).Health}");
        };

        warrior.Attack(healer);
        healer.Attack(warrior);
    }
}

class Character
{
    public string Name { get; set; }
    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            HealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public delegate void CharacterAction(Character target);

    public event EventHandler HealthChanged;

    public Character(string name, int initialHealth)
    {
        Name = name;
        Health = initialHealth;
    }

    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}!");
        target.Health -= 10;
    }
}
