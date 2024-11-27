namespace Kata_1_Striped_Yellow_Belt;

using System;

class Program
{
    static void Main(string[] args)
    {
        Character warrior = new Character("Warrior", 100);
        Character healer = new Character("Healer", 80);

        warrior.PrimaryAction = (attacker, target) =>
        {
            Console.WriteLine($"{attacker.Name} attacks {target.Name}!");
            target.TakeDamage(20);
        };

        healer.PrimaryAction = (attacker, target) =>
        {
            Console.WriteLine($"{attacker.Name} heals {target.Name}!");
            target.Heal(15);
        };

        warrior.PerformAction(healer);
        healer.PerformAction(warrior);
    }
}

class Character
{
    public string Name { get; set; }
    public int Health { get; private set; }

    public delegate void CharacterAction(Character attacker, Character target);

    public CharacterAction PrimaryAction { get; set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void PerformAction(Character target)
    {
        PrimaryAction?.Invoke(this, target);
    }

    public void TakeDamage(int amount)
    {
        Health = Math.Max(0, Health - amount);
        Console.WriteLine($"{Name}'s health is now {Health}");
    }

    public void Heal(int amount)
    {
        Health +
