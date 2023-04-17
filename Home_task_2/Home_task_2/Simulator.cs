using System;
using System.Text;

namespace Home_task_2
{
    public class Simulator
    {
        private WaterTower _waterTower;
        private Pump _pump;
        private List<User> _users;
        private readonly int _countUsers = 10; // кількість користувачів


        public Simulator()
        {
            _waterTower = new();
            _pump = new();
            _users = new List<User>();
            for (int i = 0; i < _countUsers; i++)
            {
                _users.Add(new User());
            }
        }
        public Simulator(int maxLevelWater, float power, params float[] waterConsumption)
        {
            _waterTower = new(maxLevelWater);
            _pump = new(power);
            _users = new List<User>();
            _countUsers = waterConsumption.Length;
            for (int i = 0; i < _countUsers; i++)
            {
                _users[i] = new User(waterConsumption[i]);
            }
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _users.Count; i++)
            {
                sb.Append($"{_users[i].ToString()}");
            }
            sb.Append("\n");
            sb.Append($"{_waterTower.ToString()}");
            sb.Append("\n");
            sb.Append($"{_pump.ToString()}");
            return sb.ToString();
        }

        // симуляція взаємодії башні, насоса та користувача
        public async Task WorkSimulatorAsync()
        {

        }
        public void AddUser(User user)
        {
            _users.Add(user);
        }
        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }
    }
}

