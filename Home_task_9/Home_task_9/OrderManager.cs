using System;
namespace Home_task_9
{
    public sealed class OrderManager
    {
        private static readonly OrderManager instance = new OrderManager();
        private readonly List<KitchenStaff> kitchenStaff;
        private readonly Order order;

        public event Action<string, string> OrderItemProcessed;

        private OrderManager()
        {
            kitchenStaff = new List<KitchenStaff>();
            order = new Order();
        }

        public static OrderManager Instance
        {
            get { return instance; }
        }

        public void AddKitchenStaff(KitchenStaff staff)
        {
            kitchenStaff.Add(staff);
        }

        public void ProcessOrder()
        {
            foreach (var item in order.Items)
            {
                var category = item.Category;
                var staff = GetKitchenStaffByCategory(category);
                staff?.HandleOrder(item.Name);
            }
        }

        private KitchenStaff GetKitchenStaffByCategory(string category)
        {
            foreach (var staff in kitchenStaff)
            {
                if (staff.CanHandleCategory(category))
                {
                    return staff;
                }
            }
            return null;
        }

        public void FoodProcessed(string itemName, string kitchenStaffName)
        {
            OrderItemProcessed?.Invoke(itemName, kitchenStaffName);
        }
    }

}

