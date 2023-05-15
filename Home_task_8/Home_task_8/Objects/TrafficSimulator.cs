using System;
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
                        Console.WriteLine(lane);
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
                        Console.WriteLine(lane);
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

