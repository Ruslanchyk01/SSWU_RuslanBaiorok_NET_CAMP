using System;
namespace Home_task_2
{
	public static class Validator
    {
		public static bool IsValidLevelWater(float value)
		{
			if (value < 0 && value > 15000)
			{
                throw new ArgumentException("Об'єм води не може бути від'ємний та не повинни перебільшувати 15000");
			}
			return true;
		}

        public static bool IsValidPumpPower(float value)
        {
            if (value < 0 && value > 100)
            {
                throw new ArgumentException("Потужність насоса не може бути від'ємною та не повинна перебільшувати 100");
            }
            return true;
        }

        public static bool IsValidWaterConsumption(float value)
        {
            if (value < 0 && value > 0.5)
            {
                throw new ArgumentException("Користувач не може використовувати від'ємну кількість води та не не може качати швидше ніж 0.5");
            }
            return true;
        }
    }
}

