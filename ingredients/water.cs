using System;
namespace CoffeeMachineSystem {
    public class Water : Ingredient
{
    public Water(double m) : base(m) { }
    public override string Name => "Вода";
    public override ProductType Type => ProductType.Water;
}
}

