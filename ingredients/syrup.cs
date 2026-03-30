using System;
namespace CoffeeMachineSystem {
    public class Syrup : Ingredient
{
    public Syrup(double m) : base(m) { }
    public override string Name => "Сироп";
    public override ProductType Type => ProductType.Syrup;
}
}

