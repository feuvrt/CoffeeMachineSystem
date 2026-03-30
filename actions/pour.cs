using System;
namespace CoffeeMachineSystem {
    public class PourAction : Action
{
    public PourAction() : base("Пролить (эспрессо)") { }

    protected override int MinChildren => 2;
    protected override int MaxChildren => 2;

    protected override bool IsValidSet(List<Product> inputs)
    {
        bool hasCoffee = inputs.Any(p => p.Type == ProductType.GroundCoffee);
        bool hasWater = inputs.Any(p => p.Type == ProductType.Water);

        return hasCoffee && hasWater;
    }

    protected override Product Process(List<Product> inputs)
    {
        var coffee = inputs.First(p => p.Type == ProductType.GroundCoffee);
        var water = inputs.First(p => p.Type == ProductType.Water);

        Console.WriteLine($"Пролить воду через {coffee.Pretty()}");

        var result = new Product(
            "кофе",
            "Эспрессо",
            coffee.Mass + water.Mass,
            ProductType.Espresso
        );

        Console.WriteLine($"Добавлено: {result.Pretty()}");

        return result;
    }
}
}

