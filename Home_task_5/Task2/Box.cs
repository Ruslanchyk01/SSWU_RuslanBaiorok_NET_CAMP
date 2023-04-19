using System;
namespace Task2
{
    internal class Box
    {
        public string Name { get; private set; }
        public Dimensions Dimensions { get; private set; }
        public List<Product> ListOfProducts { get; set; }

        public static List<Box> boxes { get; set; } = new List<Box>();

        public Box(string name)
        {
            Name = name;
            ListOfProducts = new List<Product>();
            Dimensions = new Dimensions(0, 0, 0);
        }
        public void PrintBoxStructure(string indent)
        {
            Console.WriteLine($"{indent}Коробка {Name}: {Dimensions.Width}x{Dimensions.Length}x{Dimensions.Height}");

            foreach (var product in ListOfProducts)
            {
                Console.WriteLine($"{indent}  - {product.Name}: {product.Dimensions.Width}x{product.Dimensions.Length}x{product.Dimensions.Height}");
            }
        }

        // Метод для додавання продукту до списку
        public void AddProduct(Product product)
        {
            ListOfProducts.Add(product);
            Dimensions = Dimensions.CalculateBoxDimensions(ListOfProducts, p => p.Dimensions);
        }

        public void CreateBox(List<Product> products)
        {
            Console.WriteLine("Додавання коробки");
            Console.WriteLine("Введіть назву коробки:");
            string name = Console.ReadLine();

            Box box = new Box(name);

            foreach (var prod in products)
            {
                box.AddProduct(prod);
            }

            boxes.Add(box);

            Console.WriteLine("Коробку додано:");
            Console.WriteLine($"Назва: {box.Name}");
            Console.WriteLine($"Габарити: {box.Dimensions.Width}x{box.Dimensions.Length}x{box.Dimensions.Height}");

            while (true)
            {
                Console.WriteLine("1. Додати ще одну коробку");
                Console.WriteLine("2. Перейти до додавання підрозділу");
                Console.WriteLine("3. Повернутись до головного меню");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Перед тим потрібно додати ще продукти");
                        products.Clear();
                        Product.CreateProduct();
                        CreateBox(products);
                        break;
                    case "2":
                        Unit unit = new("", 1);
                        unit.CreateUnit(boxes);
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

