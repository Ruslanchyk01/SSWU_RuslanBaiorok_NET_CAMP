using System;
namespace Home_task_9
{
    public class DessertStaff : KitchenStaff
    {
        public DessertStaff(string name) :
            base(name) { }

        public override bool CanHandleCategory(string category)
        {
            return category == "Dessert";
        }

        protected override void ProcessItem(string itemName)
        {
            Console.WriteLine($"Кухар '{name}' готує десерт '{itemName}'.");
        }
    }
}

