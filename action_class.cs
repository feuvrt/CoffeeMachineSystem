using System;
namespace CoffeeMachineSystem {
    public abstract class Action : IElement
{
    public string Name { get; protected set; }
    public List<IElement> Children { get; } = new();

    protected Action(string name) => Name = name;

    protected abstract int MinChildren { get; }
    protected abstract int MaxChildren { get; }

    protected abstract bool IsValidSet(List<Product> inputs);

    public Product Execute()
    {
        if (Children.Count < MinChildren || Children.Count > MaxChildren)
            throw new Exception($"❌ {Name}: неверное количество элементов");

        var inputs = Children.Select(c => c.Execute()).ToList();

        if (!IsValidSet(inputs))
        {
            string list = string.Join(", ", inputs.Select(p => p.Pretty()));
            throw new Exception($"❌ {Name}: неверная комбинация ({list})");
        }

        return Process(inputs);
    }

    protected abstract Product Process(List<Product> inputs);

    public string GetInfo(int indent = 0)
    {
        string space = new string(' ', indent);
        string res = space + $"⚡ {Name}\n";

        foreach (var c in Children)
            res += c.GetInfo(indent + 4);

        return res;
    }
}


public class AddAction : Action
{
    public AddAction() : base("Добавить") { }

    protected override int MinChildren => 1;
    protected override int MaxChildren => 10;

    protected override bool IsValidSet(List<Product> p) => true;

    protected override Product Process(List<Product> inputs)
    {
        string names = string.Join(", ", inputs.Select(p => p.Pretty()));

        Console.WriteLine($"Добавить {names}");

        var result = new Product(
            "смесь",
            "Добавлено",
            inputs.Sum(x => x.Mass),
            ProductType.Mixture
        );

        Console.WriteLine($"Добавлено: ({names})");

        return result;
    }
}

}

