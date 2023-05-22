using System;
namespace Home_task_9
{
    public abstract class KitchenStaff
    {
        protected string name;

        protected KitchenStaff(string name)
        {
            this.name = name;
        }

        public abstract bool CanHandleCategory(string category);

        public void HandleOrder(string itemName)
        {
            ProcessItem(itemName);
            OrderManager.Instance.FoodProcessed(itemName, name);
        }

        protected abstract void ProcessItem(string itemName);
    }

}

