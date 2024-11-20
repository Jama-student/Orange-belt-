namespace Level_1_Striped_Yellow_Belt;

using System;

class Program
{
    static void Main(string[] args)
    {
        
        Character warrior = new Character("Warrior", 40);
        Character healer = new Character("Healer", 60);

        
        warrior.PrimaryAction = () => Console.WriteLine("Warrior attacks the enemy!");
        healer.PrimaryAction = () => Console.WriteLine("Healer casts Heal!");

        

        if (warrior.Health < 50)
        {
            warrior.PrimaryAction.Invoke();
        }

        
        if (healer.Health < 50)
        {
            healer.PrimaryAction.Invoke();
        }
        else
        {
            
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
