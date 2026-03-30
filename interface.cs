using System;
namespace CoffeeMachineSystem {
    public interface IElement
{
    string GetInfo(int indent = 0);
    Product Execute();
}

public enum ProductType
{
    Water,
    Milk,
    CoffeeBeans,
    GroundCoffee,
    Espresso,
    MilkFoam,
    Ice,
    Syrup,
    Mixture
}
}

