namespace Kata_3._1_Orange_Belt;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the AbilityContainer to store abilities
        AbilityContainer<IAbility> container = new AbilityContainer<IAbility>();

        // Create abilities
        IAbility attack = new AttackAbility("Sword Slash", "Deal 50 damage.");
        IAbility heal = new HealAbility("Healing Light", "Heal 30 health.");

        // Add abilities to the container
        container.AddAbility(attack);
        container.AddAbility(heal);

        // Display abilities
        container.DisplayAbilities();
    }
}

// Ability Interface
public interface IAbility
{
    string Name { get; set; }
    string Effect { get; set; }
}

// AttackAbility class implementing IAbility
public class AttackAbility : IAbility
{
    public string Name { get; set; }
    public string Effect { get; set; }

    public AttackAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

// HealAbility class implementing IAbility
public class HealAbility : IAbility
{
    public string Name { get; set; }
    public string Effect { get; set; }

    public HealAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

// Generic container for abilities
public class AbilityContainer<T> where T : IAbility
{
    private List<T> abilities = new List<T>();

    // Add an ability to the container
    public void AddAbility(T ability)
    {
        abilities.Add(ability);
    }

    // Display all abilities in the container
    public void DisplayAbilities()
    {
        foreach (var ability in abilities)
        {
            Console.WriteLine($"{ability.Name}: {ability.Effect}");
        }
    }
}