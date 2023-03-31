using System;
namespace Home_task_2
{
	public class User
	{
        private static int _lastId = 0;
        private readonly int _id; // номер користувача
        private readonly float _rateWaterConsumption = 0.1f; // використання води на секунду
        private readonly int _usingWaterTime; // загальний час використання води на день


        public User()
        {
            _lastId++;
            _id = _lastId;
            Random random = new Random();
            _usingWaterTime = random.Next(3600, 10800);
        }
        public User(float rateWaterConsumption)
        {
            _lastId++;
            _id = _lastId;
            if (Validator.IsValidWaterConsumption(rateWaterConsumption))
            {
                _rateWaterConsumption = rateWaterConsumption;
            }
            Random random = new Random();
            _usingWaterTime = random.Next(3600, 10800); // користувач може в сумі використовувати воду від 1 години до 3 годин часу на день
        }

        public int Id
        {
            get { return _id; }
        }
        public float RateWaterConsumption
        {
            get { return _rateWaterConsumption; }
        }
        public float UsingWaterTime
        {
            get { return _usingWaterTime; }
        }


        public override string? ToString()
        {
            return $"Користувач {_id} використав стільки води за день: {UsingWaterPerDay()}л;\n";
        }


        // використання води користувачем на день
        public float UsingWaterPerDay()
        {
            return _rateWaterConsumption * _usingWaterTime;
        }
    }
}

