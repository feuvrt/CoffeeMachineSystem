using System;
namespace CoffeeMachineSystem {
    public class DrinkManager
{
    private Dictionary<string, Drink> menu = new();

    public void CreateDrink()
    {
        Console.Write("Название напитка: ");
        string name = Console.ReadLine();

        var drink = new Drink(name);
        drink.Root = BuildTree();

        menu[name] = drink;
        Console.WriteLine("✔ Напиток добавлен");
    }

    private IElement BuildTree()
    {
        Action action = ChooseAction();
        

        while (true)
        {
            Console.WriteLine("\n1. Добавить ингредиент");
            Console.WriteLine("2. Добавить действие");
            Console.WriteLine("0. Готово");

            string ch = Console.ReadLine();

            if (ch == "0") break;

            if (ch == "1")
                action.Children.Add(CreateIngredient());

            if (ch == "2")
                action.Children.Add(BuildTree());
        }

        return action;
    }

    private Action ChooseAction()
    {
        Console.WriteLine("\nВыбери действие:");
        Console.WriteLine("1 Добавить");
        Console.WriteLine("2 Перемешать");
        Console.WriteLine("3 Вскипятить");
        Console.WriteLine("4 Взбить");
        Console.WriteLine("5 Перемолоть");
        Console.WriteLine("6 Пролить");

        return Console.ReadLine() switch
        {
            "1" => new AddAction(),
            "2" => new MixAction(),
            "3" => new BoilAction(),
            "4" => new WhipAction(),
            "5" => new GrindAction(),
            "6" => new PourAction(),
            _ => new AddAction()
        };
    }

    private Ingredient CreateIngredient()
    {
        Console.WriteLine("\nВыбери ингредиент:");
        Console.WriteLine("1 Вода");
        Console.WriteLine("2 Молоко");
        Console.WriteLine("3 Кофе");
        Console.WriteLine("4 Сироп");
        Console.WriteLine("5 Лёд");

        string choice = Console.ReadLine();

        Console.Write("Количество: ");
        double m = double.Parse(Console.ReadLine());

        return choice switch
        {
            "1" => new Water(m),
            "2" => new Milk(m),
            "3" => new CoffeeBean(m),
            "4" => new Syrup(m),
            "5" => new Ice(m),
            _ => new Water(m)
        };
    }

    public void ReadMenu()
    {
        foreach (var d in menu.Values)
        {
            Console.WriteLine($"\n--- {d.Name} ---");
            Console.WriteLine(d.Root.GetInfo());
        }
    }

    public void UpdateDrink()
    {
        Console.Write("Название: ");
        string name = Console.ReadLine();

        if (!menu.ContainsKey(name)) return;

        Console.WriteLine("1 Переименовать\n2 Пересоздать");
        string ch = Console.ReadLine();

        if (ch == "1")
        {
            Console.Write("Новое имя: ");
            string newName = Console.ReadLine();

            var d = menu[name];
            menu.Remove(name);
            d.Name = newName;
            menu[newName] = d;
        }
        else if (ch == "2")
        {
            menu[name].Root = BuildTree();
        }
    }

    public void DeleteDrink()
    {
        Console.Write("Название: ");
        menu.Remove(Console.ReadLine());
    }

    public Drink BuildEspresso()
    {
        var grind = new GrindAction();
        grind.Children.Add(new CoffeeBean(18));

        var boil = new BoilAction();
        boil.Children.Add(new Water(40));

        var pour = new PourAction();
        pour.Children.Add(grind);
        pour.Children.Add(boil);

        return new Drink("Эспрессо") { Root = pour };
    }
    public Drink BuildAmericano()
    {
        var espresso = BuildEspresso().Root;

        var hotWater = new BoilAction();
        hotWater.Children.Add(new Water(100));

        var mix = new MixAction();
        mix.Children.Add(espresso);
        mix.Children.Add(hotWater);

        return new Drink("Американо") { Root = mix };
    }
    public Drink BuildLatte()
    {
        var espresso = BuildEspresso().Root;

        var milk = new BoilAction();
        milk.Children.Add(new Milk(150));

        var mix = new MixAction();
        mix.Children.Add(espresso);
        mix.Children.Add(milk);

        return new Drink("Латте") { Root = mix };
    }
    public Drink BuildCappuccino()
    {
        var espresso = BuildEspresso().Root;

        var milk = new WhipAction();
        milk.Children.Add(new Milk(100));

        var mix = new MixAction();
        mix.Children.Add(espresso);
        mix.Children.Add(milk);

        return new Drink("Капучино") { Root = mix };
    }
    public Drink BuildRaf()
    {
        var espresso = BuildEspresso().Root;

        var milk = new WhipAction();
        milk.Children.Add(new Milk(120));

        var syrup = new Syrup(20);

        var mix = new MixAction();
        mix.Children.Add(espresso);
        mix.Children.Add(milk);
        mix.Children.Add(syrup);

        return new Drink("Раф с сиропом") { Root = mix };
    }

    public void AddDefaults()
    {
        var drinks = new List<Drink>
{
    BuildEspresso(),
    BuildAmericano(),
    BuildLatte(),
    BuildCappuccino(),
    BuildRaf()
};

        foreach (var d in drinks)
            menu[d.Name] = d;
    }
    public Drink Get(string name)
        => menu.ContainsKey(name) ? menu[name] : null;
}
}

