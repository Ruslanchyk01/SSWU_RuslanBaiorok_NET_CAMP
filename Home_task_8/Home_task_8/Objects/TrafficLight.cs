using System;
using Home_task_8.Enums;
using Home_task_8.Interfaces;

namespace Home_task_8.Objects
{
    public delegate void LightChangedEvent(TrafficLight trafficLight, bool isGreenArrow);

    public class TrafficLight : ITrafficLight
    {
        private LightColor _currentColor;

        private int _redDuration;
        private int _yellowDuration;
        private int _greenDuration;

        private int _greenArrowDuration;
        private bool _isGreenArrow = false;

        private int greenArrowAfterRed;

        public TrafficLight(int redDuration, int yellowDuration, int greenDuration, LightColor color, bool isGreenArrow)
        {
            TrafficLightValidator.ValidateDurations(redDuration, yellowDuration, greenDuration);

            _redDuration = redDuration;
            _yellowDuration = yellowDuration;
            _greenDuration = greenDuration;
            _currentColor = color;
            _isGreenArrow = isGreenArrow;
            if (_isGreenArrow)
            {
                greenArrowAfterRed = _redDuration / 3;
                _greenArrowDuration = redDuration + yellowDuration + greenDuration - greenArrowAfterRed;
            }
        }

        public LightColor CurrentColor { get => _currentColor; set => _currentColor = value; }

        public int RedDuration { get => _redDuration; }
        public int GreenDuration { get => _greenDuration; }

        public event LightChangedEvent LightChanged;

        public override string? ToString()
        {
            if(_isGreenArrow)
                return $"{LightColor.Red} = {_redDuration}sec;\n{LightColor.Yellow} = {_yellowDuration}sec;\n{LightColor.Green} = {_greenDuration}sec;\n{LightColor.GreenArrow} = {_greenArrowDuration}sec.\n";
            else
                return $"{LightColor.Red} = {_redDuration}sec;\n{LightColor.Yellow} = {_yellowDuration}sec;\n{LightColor.Green} = {_greenDuration}sec.\n";

        }

        public void SwitchColor()
        {
            switch (_currentColor)
            {
                case LightColor.Red:
                    if (_isGreenArrow)
                    {
                        Thread.Sleep((_redDuration - greenArrowAfterRed) * 1000);
                        LightChanged?.Invoke(this, _isGreenArrow);
                        Thread.Sleep(greenArrowAfterRed * 1000);
                        _currentColor = LightColor.Yellow;
                        LightChanged?.Invoke(this, _isGreenArrow);

                    }
                    else
                    {
                        Thread.Sleep(_redDuration * 1000);
                        _currentColor = LightColor.Yellow;
                        LightChanged?.Invoke(this, _isGreenArrow);
                    }
                    break;
                case LightColor.Yellow:
                    Thread.Sleep(_yellowDuration * 1000);
                    _currentColor = LightColor.Green;
                    LightChanged?.Invoke(this, _isGreenArrow);
                    break;
                case LightColor.Green:
                    Thread.Sleep(_greenDuration * 1000);
                    _currentColor = LightColor.Red;
                    if(_isGreenArrow)
                        LightChanged?.Invoke(this, !_isGreenArrow);
                    else
                        LightChanged?.Invoke(this, _isGreenArrow);
                    break;
            }
        }

        public void SetLightDurations(int redDuration, int yellowDuration, int greenDuration)
        {
            TrafficLightValidator.ValidateDurations(redDuration, yellowDuration, greenDuration);
            _redDuration = redDuration;
            _yellowDuration = yellowDuration;
            _greenDuration = greenDuration;
            if (_isGreenArrow)
            {
                greenArrowAfterRed = _redDuration / 3;
                _greenArrowDuration = redDuration + yellowDuration + greenDuration - greenArrowAfterRed;
            }
        }
    }
}

