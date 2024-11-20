namespace Kata_3._1_Orange_Belt;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        AbilityContainer<IAbility> container = new AbilityContainer<IAbility>();

        
        IAbility attack = new AttackAbility("Sword Slash", "Deal 50 damage.");
        IAbility heal = new HealAbility("Healing Light", "Heal 30 health.");

        
        container.AddAbility(attack);
        container.AddAbility(heal);

    
        container.DisplayAbilities();
    }
}


public interface IAbility
{
    string Name { get; set; }
    string Effect { get; set; }
}


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


public class AbilityContainer<T> where T : IAbility
{
    private List<T> abilities = new List<T>();

    
    public void AddAbility(T ability)
    {
        abilities.Add(ability);
    }

    
    public void DisplayAbilities()
    {
        foreach (var ability in abilities)
        {
            Console.WriteLine($"{ability.Name}: {ability.Effect}");
        }
    }
}
