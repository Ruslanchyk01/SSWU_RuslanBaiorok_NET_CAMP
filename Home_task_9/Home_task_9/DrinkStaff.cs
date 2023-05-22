using System;
namespace Home_task_9
{
    public class DrinkStaff : KitchenStaff
    {
        public DrinkStaff(string name) : base(name) { }

        public override bool CanHandleCategory(string category)
        {
            return category == "Drink";
        }

        protected override void ProcessItem(string itemName)
        {
            Console.WriteLine($"Кухар '{name}' готує напій '{itemName}'.");
        }
    }

}

