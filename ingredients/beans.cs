using System;
namespace CoffeeMachineSystem {
    public class CoffeeBean : Ingredient
{
    public CoffeeBean(double m) : base(m) { }
    public override string Name => "Кофе";
    public override ProductType Type => ProductType.CoffeeBeans;
}
}

