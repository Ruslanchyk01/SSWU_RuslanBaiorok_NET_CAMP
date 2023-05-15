using System;
using Home_task_8.Enums;
using Home_task_8.Objects;

namespace Home_task_8.Interfaces
{
    public interface ITrafficLight
    {
        LightColor CurrentColor { get; set; }
        int RedDuration { get; }
        int GreenDuration { get; }
        event LightChangedEvent LightChanged;

        void SwitchColor();
        void SetLightDurations(int redDuration, int yellowDuration, int greenDuration);
    }

}

