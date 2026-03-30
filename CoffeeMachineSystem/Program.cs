using System;
namespace CoffeeMachineSystem {
class Program
{
    static void Main()
    {
        var m = new DrinkManager();
        m.AddDefaults();

        while (true)
        {
            Console.WriteLine("\n1 Посмотреть меню\n2 Создать напиток\n3 Обновить напиток\n4 Удалить напиток\n0 Выход");
            switch (Console.ReadLine())
            {
                case "1": m.ReadMenu(); break;
                case "2": m.CreateDrink(); break;
                case "3": m.UpdateDrink(); break;
                case "4": m.DeleteDrink(); break;
                case "0": return;
            }
        }
    }
}
}

