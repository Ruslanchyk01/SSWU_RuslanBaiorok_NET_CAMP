using System;
namespace Traffic_lights
{
    public interface ITrafficLight
    {
        string Name { get; }
        LightColor CurrentColor { get; }
        event LightChangedEvent LightChanged;
        void SwitchColor();
        void SetLightDurations(int redDuration, int yellowDuration, int greenDuration);
    }
}

