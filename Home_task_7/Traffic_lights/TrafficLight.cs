using System;

namespace Traffic_lights
{
    // делегат, що сповіщатиме про зміну кольору
    public delegate void LightChangedEvent(TrafficLight trafficLight);

    public class TrafficLight : ITrafficLight
    {
        private LightColor _currentColor;
        private string _name;
        private int _redDuration;
        private int _yellowDuration;
        private int _greenDuration;


        public TrafficLight(string name, int redDuration, int yellowDuration, int greenDuration, LightColor color)
        {
            _name = name;
            _greenDuration = greenDuration;
            _yellowDuration = yellowDuration;
            _redDuration = redDuration;
            _currentColor = color;
        }

        public string Name { get => _name; }

        public LightColor CurrentColor { get => _currentColor; }

        // івент для сповіщення про зміну кольору світлофора
        public event LightChangedEvent LightChanged;

        public override string? ToString()
        {
            return $"{_name}:\n{LightColor.Red} = {_redDuration}sec;\n{LightColor.Yellow} = {_yellowDuration}sec;\n{LightColor.Green} = {_greenDuration}sec.\n";
        }

        // метод для переключення кольорів
        public void SwitchColor()
        {
            switch (_currentColor)
            {
                case LightColor.Red:
                    Thread.Sleep(_redDuration * 1000);
                    _currentColor = LightColor.Yellow;
                    LightChanged?.Invoke(this);
                    break;
                case LightColor.Yellow:
                    Thread.Sleep(_yellowDuration * 1000);
                    _currentColor = LightColor.Green;
                    LightChanged?.Invoke(this);
                    break;
                case LightColor.Green:
                    Thread.Sleep(_greenDuration * 1000);
                    _currentColor = LightColor.Red;
                    LightChanged?.Invoke(this);
                    break;
            }
        }

        // метод для зміни таймерів кольорів
        public void SetLightDurations(int redDuration, int yellowDuration, int greenDuration)
        {
            _redDuration = redDuration;
            _yellowDuration = yellowDuration;
            _greenDuration = greenDuration;
        }
    }
}

