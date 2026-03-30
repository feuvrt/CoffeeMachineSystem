using System;
namespace CoffeeMachineSystem {
    public class BoilAction : Action
{
    public BoilAction() : base("Вскипятить") { }

    protected override int MinChildren => 1;
    protected override int MaxChildren => 3;

    protected override bool IsValidSet(List<Product> inputs)
        => inputs.All(p => p.Type == ProductType.Water || p.Type == ProductType.Milk);

    protected override Product Process(List<Product> inputs)
    {
        var p = inputs[0];

        var result = new Product(
            p.Name,
            "Кипячёная",
            p.Mass,
            p.Type 
        );

        Console.WriteLine($"Вскипятить {p.Pretty()}");
        Console.WriteLine($"Добавлено: {result.Pretty()}");

        return result;
    }
}
}

