using System;
namespace CoffeeMachineSystem {
    public class Ice : Ingredient
{
    public Ice(double m) : base(m) { }
    public override string Name => "Лёд";
    public override ProductType Type => ProductType.Ice;
}
}

