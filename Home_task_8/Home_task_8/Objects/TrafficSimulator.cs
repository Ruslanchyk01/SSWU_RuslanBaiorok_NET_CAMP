using System;
using System.Text;
using Home_task_8.Interfaces;

namespace Home_task_8.Objects
{
    public class TrafficSimulator : ITrafficSimulator
    {
        private readonly List<Crossroad> _crossroads;

        public TrafficSimulator(List<Crossroad> crossroads)
        {
            _crossroads = crossroads;
        }

        public List<Crossroad> Crossroads { get => _crossroads; }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var crossroad in _crossroads)
            {
                sb.Append(crossroad);
            }
            return sb.ToString();
        }

        public void Simulation()
        {
            Console.WriteLine("Starting traffic simulation...");
            Console.WriteLine("---------------------------------------------");

            while (!Console.KeyAvailable)
            {
                foreach (var crossroad in _crossroads)
                {
                    Console.WriteLine($"Crossroad {crossroad.Id}:");
                    foreach (var lane in crossroad.Lanes)
                    {
                        lane.TrafficLight.SwitchColor();
                    }
                    foreach (var lane in crossroad.Lanes)
                    {
                        Console.WriteLine($"Lane {lane.Direction}: {lane.TrafficLight.CurrentColor}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Current state of lanes:");
                foreach (var crossroad in _crossroads)
                {
                    Console.WriteLine($"Crossroad {crossroad.Id}:");
                    foreach (var lane in crossroad.Lanes)
                    {
                        Console.WriteLine($"Lane {lane.Direction}: {lane.TrafficLight.CurrentColor}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------------------------------\n");
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Traffic simulation completed.");
        }
    }
}

