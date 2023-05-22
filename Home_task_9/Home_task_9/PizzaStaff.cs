using System;
namespace Home_task_9
{
    public class PizzaStaff : KitchenStaff
    {
        public PizzaStaff(string name) : base(name) { }

        public override bool CanHandleCategory(string category)
        {
            return category == "Pizza";
        }

        protected override void ProcessItem(string itemName)
        {
            Console.WriteLine($"Кухар '{name}' готує піцу '{itemName}'.");
        }
    }

}

