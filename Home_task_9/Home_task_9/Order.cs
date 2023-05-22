using System;
namespace Home_task_9
{
    public class Order
    {
        public List<MenuItem> Items { get; }

        public Order()
        {
            Items = new List<MenuItem>
            {
                new MenuItem { Name = "Піца 4 сири", Category = "Pizza" },
                new MenuItem { Name = "Піца Гавайська", Category = "Pizza" },
                new MenuItem { Name = "Десерт Райський", Category = "Dessert" },
                new MenuItem { Name = "Тірамісу", Category = "Dessert" },
                new MenuItem { Name = "Сік ананасовий", Category = "Drink" }
            };
        }
    }
}

