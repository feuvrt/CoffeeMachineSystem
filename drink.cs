using System;
namespace CoffeeMachineSystem{
    public class Drink {
    public string Name { get; set; }
    public IElement Root { get; set; }

    public Drink(string name) => Name = name;

    public void Prepare()
    {
        Console.WriteLine($"\n=== ГОТОВИМ {Name.ToUpper()} ===");

        if (Root == null)
        {
            Console.WriteLine(" Рецепт не задан");
            return;
        }

        try
        {
            var result = Root.Execute();
            Console.WriteLine($"\n✔ ГОТОВО: {result.Pretty()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

}

