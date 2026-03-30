using System;
namespace CoffeeMachineSystem {
    public class GrindAction : Action
{
    public GrindAction() : base("Перемолоть") { }

    protected override int MinChildren => 1;
    protected override int MaxChildren => 1;

    protected override bool IsValidSet(List<Product> inputs)
        => inputs[0].Type == ProductType.CoffeeBeans;

    protected override Product Process(List<Product> inputs)
    {
        var p = inputs[0];

        var result = new Product(
            "кофе",
            "Молотый",
            p.Mass,
            ProductType.GroundCoffee
        );

        Console.WriteLine($"Перемолоть {p.Pretty()}");
        Console.WriteLine($"Добавлено: {result.Pretty()}");

        return result;
    }
}
}

