using System;
using Home_task_8.Interfaces;

namespace Home_task_8.Objects
{
    public class Crossroad : ICrossroad
    {
        private static int _lastId = 0;
        private List<Lane> _lanes;

        public Crossroad(List<Lane> lanes)
        {
            TrafficLightValidator.ValidateLanes(lanes);
            Id = _lastId++;
            _lanes = lanes;

            foreach (Lane lane in _lanes)
            {
                lane.TrafficLight.LightChanged -= TrafficLightChanged;
                lane.TrafficLight.LightChanged += TrafficLightChanged;
            }
        }


        public int Id { get; }
        public List<Lane> Lanes { get => _lanes; }

        private void TrafficLightChanged(TrafficLight trafficLight, bool isGreenArrow)
        {
            string greenArrowInfo = isGreenArrow ? "Green arrow is ON" : "Green arrow is OFF";
            Lane lane = _lanes.FirstOrDefault(l => l.TrafficLight == trafficLight);

            if (lane != null)
            {
                Console.WriteLine($"Traffic light in lane {lane.Direction} is {trafficLight.CurrentColor} now. {greenArrowInfo}");
            }
        }
    }
}


