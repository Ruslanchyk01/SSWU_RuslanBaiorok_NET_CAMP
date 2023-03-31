using System;
namespace Home_task_2
{
	public class WaterTower
	{
		private readonly int _maxLevelWater = 1000; // загальна вмістимість башні
		private float _currentLevelWater; // поточний рівень води у башні

        public WaterTower()
        {
            _currentLevelWater = _maxLevelWater;
        }
        public WaterTower(int maxLevelWater)
        {
            if (Validator.IsValidLevelWater(maxLevelWater))
            {
                _maxLevelWater = maxLevelWater;
                _currentLevelWater = maxLevelWater;
            }
        }

        public float MaxLevelWater
        {
            get { return _maxLevelWater; }
        }
        public float CurrentWaterLevel
        {
            get { return _currentLevelWater; }
        }


        public override string? ToString()
        {
            return $"Максимальна вмістимість вежі: {_maxLevelWater}л;\nПоточний рівень води у вежі: {_currentLevelWater}л.\n";
        }


        // Збільшення/зменшення води у башні
        public async Task IncreaseWaterAsync()
        {

        }
        public async Task DecreaseWaterAsync()
        {

        }
    }
}

