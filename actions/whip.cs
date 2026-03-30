using System;
namespace CoffeeMachineSystem {
    public class WhipAction : Action
{
    public WhipAction() : base("Взбить") { }

    protected override int MinChildren => 1;
    protected override int MaxChildren => 1;

    protected override bool IsValidSet(List<Product> inputs)
        => inputs[0].Type == ProductType.Milk;

    protected override Product Process(List<Product> inputs)
    {
        var p = inputs[0];

        var result = new Product(
            "молоко",
            "Взбитое",
            p.Mass,
            ProductType.MilkFoam
        );

        Console.WriteLine($"Взбить {p.Pretty()}");
        Console.WriteLine($"Добавлено: {result.Pretty()}");

        return result;
    }
}
}

