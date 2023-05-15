using System;
using Home_task_8.Enums;
using Home_task_8.Interfaces;

namespace Home_task_8.Objects
{
    public class Lane : ILane
    {
        private readonly TrafficLight _trafficLight;
        private readonly LaneDirection _direction;

        public Lane(LaneDirection direction, TrafficLight trafficLight)
        {
            _direction = direction;
            _trafficLight = trafficLight;
        }

        public LaneDirection Direction { get => _direction; }
        public TrafficLight TrafficLight { get => _trafficLight; }

        public override string? ToString()
        {
            return $"Lane {Direction}: {TrafficLight.CurrentColor}";
        }
    }
}

