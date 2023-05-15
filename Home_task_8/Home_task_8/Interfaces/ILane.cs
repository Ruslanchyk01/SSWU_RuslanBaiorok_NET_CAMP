using System;
using Home_task_8.Enums;
using Home_task_8.Objects;

namespace Home_task_8.Interfaces
{
    public interface ILane
    {
        LaneDirection Direction { get; }
        TrafficLight TrafficLight { get; }
    }
}

