using System;
namespace CoffeeMachineSystem {
    public class MixAction : Action
{
    public MixAction() : base("Перемешать") { }

    protected override int MinChildren => 2;
    protected override int MaxChildren => 10;

    protected override bool IsValidSet(List<Product> inputs)
        => inputs.Count >= 2;

    protected override Product Process(List<Product> inputs)
    {
        string names = string.Join(", ", inputs.Select(p => p.Pretty()));

        Console.WriteLine($"Перемешать {names}");

        var result = new Product(
            "смесь",
            "Перемешанный",
            inputs.Sum(x => x.Mass),
            ProductType.Mixture
        );

        Console.WriteLine($"Добавлено: ({names})");

        return result;
    }
}
}

