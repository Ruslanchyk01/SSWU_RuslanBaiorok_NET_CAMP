using System;
namespace Home_task_2
{
	public class Pump
	{
        private readonly float _power = 5.5f; // швидкість закачування води в башню (л/с)
        private bool _isON = false; // стан насоса


        public Pump()
        {
        }
        public Pump(float power)
        {
            if (Validator.IsValidPumpPower(power))
            {
                _power = power;
            }
        }

        public float Power
        {
            get { return _power; }
        }
        public bool IsON
        {
            get { return _isON; }
        }


        public override string? ToString()
        {
            return $"Потужність насоса: {_power}л/c.\n";
        }


        // вмикання/вимикання насосу
        public void TurnON()
        {
            _isON = true;
        }
        public void TurnOFF()
        {
            _isON = false;
        }
    }
}

