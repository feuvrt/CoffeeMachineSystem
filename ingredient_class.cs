using System;
namespace CoffeeMachineSystem {
    public abstract class Ingredient : IElement
{
    public double Mass { get; set; }

    protected Ingredient(double m) => Mass = m;

    public abstract string Name { get; }
    public abstract ProductType Type { get; }

    public Product Execute()
    {
        return new Product(Name, "", Mass, Type);
    }

    public string GetInfo(int indent = 0)
    {
        return new string(' ', indent) + $"🧱 {Name} ({Mass}г)\n";
    }
}

public class Product : IElement
{
    public string Name { get; set; }   
    public string State { get; set; }    
    public double Mass { get; set; }
    public ProductType Type { get; set; }

    public Product(string name, string state, double mass, ProductType type)
    {
        Name = name;
        State = state;
        Mass = mass;
        Type = type;
    }

    public Product Execute() => this;

    public string GetInfo(int indent = 0)
    {
        string statePart = string.IsNullOrEmpty(State) ? "" : $"{State} ";
        return new string(' ', indent) + $"✔ {statePart}{Name} ({Mass}г)\n";
    }

    public string Pretty()
    {
        string statePart = string.IsNullOrEmpty(State) ? "" : $"{State} ";
        return $"{statePart}'{Name}' ({Mass}г)";
    }
}

}

