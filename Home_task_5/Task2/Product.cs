using System;
namespace Task2
{
    internal class Product
    {
        public string Name { get; private set; }
        public Dimensions Dimensions { get; private set; }
        public static List<Product> products { get; set; } = new List<Product>();

        public Product(string name, Dimensions dimensions)
        {
            Name = name;
            Dimensions = dimensions;
        }

        public static void CreateProduct()
        {
            Console.WriteLine("Додавання продукту");
            Console.WriteLine("Введіть назву продукту:");
            string name = Console.ReadLine();

            Console.WriteLine("Введіть габарити:");
            Console.WriteLine("Ширина:");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Довжина:");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Висота:");
            int height = int.Parse(Console.ReadLine());

            Dimensions dimensions = new Dimensions(width, length, height);

            Product product = new Product(name, dimensions);
            products.Add(product);

            Console.WriteLine("Продукт додано:");
            Console.WriteLine($"Назва: {product.Name}");
            Console.WriteLine($"Габарити: {product.Dimensions.Width}x{product.Dimensions.Length}x{product.Dimensions.Height}");

            while (true)
            {
                Console.WriteLine("1. Додати ще один продукт");
                Console.WriteLine("2. Перейти до додавання коробки");
                Console.WriteLine("3. Повернутись до головного меню");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateProduct();
                        break;
                    case "2":
                        Box box = new("");
                        box.CreateBox(products);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неправильний вибір");
                        break;
                }
            }
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}

