using System;
namespace Task2
{// магазин - це тільки юніт 0-го рівня)
    // але у вас не правильно додаються елементи до рівнів і нема продуманого алгоритму обходу по деревовидній системі.
    internal class Shop
    {
        public string Name { get; private set; }
        public Dimensions Dimensions { get; private set; }
        public List<Unit> ListOfUnits { get; set; }

        public Shop(string name)
        {
            Name = name;
            ListOfUnits = new List<Unit>();
            //Dimensions = Dimensions.CalculateBoxDimensions(ListOfUnits, p => p.Dimensions);
        }

        // Метод для виведення структури магазину
        public void PrintShopStructure()
        {
            Console.WriteLine($"{Name}: {Dimensions.Width}x{Dimensions.Length}x{Dimensions.Height}");

            foreach (var unit in ListOfUnits)
            {
                unit.PrintDepartmentStructure("  ");
            }
        }

        public void AddUnit(Unit unit)
        {
            ListOfUnits.Add(unit);
            Dimensions = Dimensions.CalculateBoxDimensions(ListOfUnits, p => p.Dimensions);
        }

        public void CreateShop(List<Unit> units)
        {
            Console.WriteLine("Додавання магазину");
            Console.WriteLine("Введіть назву магазину:");
            string name = Console.ReadLine();

            Shop shop = new Shop(name);

            foreach (var unit in units)
            {
                shop.AddUnit(unit);
            }

            Console.WriteLine("Магазин додано:");
            Console.WriteLine($"Назва: {shop.Name}");
            Console.WriteLine($"Габарити: {shop.Dimensions.Width}x{shop.Dimensions.Length}x{shop.Dimensions.Height}");

            shop.PrintShopStructure();
        }
    }
}

