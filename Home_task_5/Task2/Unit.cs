using System;
namespace Task2
{
    internal class Unit
    {
        public string Name { get; private set; }
        public int NestedLevel { get; private set; }
        public Dimensions Dimensions { get; private set; }
        public List<Unit> ListOfSubUnits { get; set; }
        public List<Box> ListOfBoxes { get; set; }

        public static List<Unit> Units { get; set; } = new List<Unit>();

        public Unit(string name, int nestedLevel)
        {
            Name = name;
            NestedLevel = nestedLevel;
            ListOfBoxes = new List<Box>();
            ListOfSubUnits = new List<Unit>();
            Dimensions = new Dimensions(0, 0, 0);
        }

        // Метод для виведення структури підрозділу
        public void PrintDepartmentStructure(string indent)
        {
            Console.WriteLine($"{indent}Підрозділ {Name}: {Dimensions.Width}x{Dimensions.Length}x{Dimensions.Height}");

            foreach (var box in ListOfBoxes)
            {
                box.PrintBoxStructure(indent + "  ");
            }

            foreach (var unit in ListOfSubUnits)
            {
                unit.PrintDepartmentStructure(indent + "  ");
            }
        }

        public void AddBox(Box box)
        {
            ListOfBoxes.Add(box);
            Dimensions = Dimensions.CalculateBoxDimensions(ListOfBoxes, p => p.Dimensions);
        }

        public void AddUnit(Unit unit)
        {
            ListOfSubUnits.Add(unit);
            Dimensions = Dimensions.CalculateBoxDimensions(ListOfSubUnits, p => p.Dimensions);
        }

        public void CreateUnit(List<Box> boxes)
        {
            Console.WriteLine("Додавання підрозділу");
            Console.WriteLine("Введіть назву підрозділу:");
            string name = Console.ReadLine();
            Console.Write("Введіть рівень вкладеності підрозділу: ");
            int nestedLevel = int.Parse(Console.ReadLine());

            Unit unit = new Unit(name, nestedLevel);

            foreach (var box in boxes)
            {
                unit.AddBox(box);
            }
            Units.Add(unit);

            Console.WriteLine("Підрозділ додано:");
            Console.WriteLine($"Назва: {unit.Name}");
            Console.WriteLine($"Рівень: {unit.NestedLevel}");
            Console.WriteLine($"Габарити: {unit.Dimensions.Width}x{unit.Dimensions.Length}x{unit.Dimensions.Height}");


            while (true)
            {
                Console.WriteLine("1. Додати ще один підрозділ");
                Console.WriteLine("2. Перейти до додавання магазину");
                Console.WriteLine("3. Повернутись до головного меню");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Перед тим потрібно додати ще коробки з продуктами");
                        boxes.Clear();
                        Product.products.Clear();
                        Product.CreateProduct();
                        CreateUnit(boxes);
                        break;
                    case "2":
                        Shop shop = new("");
                        shop.CreateShop(Units);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неправильний вибір");
                        break;
                }
            }
        }
    }
}

