using System;
namespace Task2
{
    public class Menu
    {
        public static void StartMenu()
        {
            Product product1 = new("Лосось", new Dimensions(1, 1, 1));
            Product product2 = new("Скумбрія", new Dimensions(1, 2, 2));
            Product product3 = new("Щука", new Dimensions(3, 4, 9));

            Product product4 = new("Лего", new Dimensions(1, 5, 3));
            Product product5 = new("Лялька", new Dimensions(2, 2, 2));
            Product product6 = new("Машинка", new Dimensions(1, 9, 3));

            Product product7 = new("Акуала", new Dimensions(7, 2, 3));
            Product product8 = new("Кит", new Dimensions(1, 5, 2));
            Product product9 = new("Скат", new Dimensions(1, 3, 3));

            Box box1 = new("Риба");
            box1.AddProduct(product1);
            box1.AddProduct(product2);
            box1.AddProduct(product3);
            Box box2 = new("Іграшки");
            box2.AddProduct(product4);
            box2.AddProduct(product5);
            box2.AddProduct(product6);
            Box box3 = new("Солона риба");
            box3.AddProduct(product7);
            box3.AddProduct(product8);
            box3.AddProduct(product9);

            Unit unit1 = new("Продукти", 1);
            unit1.AddBox(box1);
            Unit unit2 = new("Для дітей", 1);
            unit2.AddBox(box2);
            unit2.AddBox(box1);

            Unit unit3 = new("Океан", 2);
            unit3.AddBox(box1);
            unit1.AddUnit(unit3); //підрозділ в підрозділі

            Shop shop = new("Барвінок");
            shop.AddUnit(unit1);
            shop.AddUnit(unit2);

            while (true)
            {
                Console.WriteLine("1. Додати структуру");
                Console.WriteLine("2. Вивести структуру");
                Console.WriteLine("3. Вийти");

                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Product.CreateProduct();
                        break;
                    case "2":
                        shop.PrintShopStructure();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір");
                        break;
                }
            }
        }
    }
}

