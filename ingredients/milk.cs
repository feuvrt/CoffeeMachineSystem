using System;
namespace CoffeeMachineSystem {
    public class Milk : Ingredient
{
    public Milk(double m) : base(m) { }
    public override string Name => "Молоко";
    public override ProductType Type => ProductType.Milk;
}
}

