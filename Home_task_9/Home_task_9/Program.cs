using System;
using Home_task_9;

var drinkStaff = new DrinkStaff("Віра");
var pizzaStaff = new PizzaStaff("Надія");
var dessertStaff = new DessertStaff("Любов");

OrderManager.Instance.AddKitchenStaff(drinkStaff);
OrderManager.Instance.AddKitchenStaff(pizzaStaff);
OrderManager.Instance.AddKitchenStaff(dessertStaff);

OrderManager.Instance.OrderItemProcessed += HandleItemProcessed;

OrderManager.Instance.ProcessOrder();

static void HandleItemProcessed(string itemName, string kitchenStaffName)
{
    Console.WriteLine($"Страва '{itemName}' оброблена кухарем '{kitchenStaffName}'.");
}
