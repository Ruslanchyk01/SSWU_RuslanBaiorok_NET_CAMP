using System;
using Home_task_8.Enums;
using Home_task_8.Interfaces;
using Home_task_8.Objects;

namespace Home_task_8
{
    class Controller : IController
    {
        private readonly TrafficSimulator _trafficSimulator;

        public Controller(TrafficSimulator trafficSimulator)
        {
            _trafficSimulator = trafficSimulator;
        }

        private void ChangeLightDurations()
        {
            Console.WriteLine("Select a crossroad:");
            for (int i = 0; i < _trafficSimulator.Crossroads.Count; i++)
            {
                Crossroad crossroad = _trafficSimulator.Crossroads[i];
                Console.WriteLine($"[{i}] {crossroad.Id}");
            }

            int crossroadIndex;
            while (true)
            {
                Console.Write("Enter the index of the crossroad: ");
                if (int.TryParse(Console.ReadLine(), out crossroadIndex) && crossroadIndex >= 0 && crossroadIndex < _trafficSimulator.Crossroads.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid crossroad index. Please try again.");
            }

            Crossroad selectedCrossroad = _trafficSimulator.Crossroads[crossroadIndex];
            List<Lane> lanes = selectedCrossroad.Lanes;

            Console.WriteLine($"Selected crossroad: {selectedCrossroad.Id}");
            Console.WriteLine("Select a lane:");
            for (int i = 0; i < lanes.Count; i++)
            {
                Lane lane = lanes[i];
                Console.WriteLine($"[{i}] {lane.Direction}");
            }

            int laneIndex;
            while (true)
            {
                Console.Write("Enter the index of the lane: ");
                if (int.TryParse(Console.ReadLine(), out laneIndex) && laneIndex >= 0 && laneIndex < lanes.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid lane index. Please try again.");
            }

            bool isValid = false;
            int newRedDuration = 0;
            int newYellowDuration = 0;
            int newGreenDuration = 0;

            while (!isValid)
            {
                Console.WriteLine("Enter the new duration for each light color:");
                Console.Write($"Red: ");
                newRedDuration = int.Parse(Console.ReadLine());
                Console.Write($"Yellow: ");
                newYellowDuration = int.Parse(Console.ReadLine());
                Console.Write($"Green: ");
                newGreenDuration = int.Parse(Console.ReadLine());

                isValid = TrafficLightValidator.ValidateDurations(newRedDuration, newYellowDuration, newGreenDuration);
                if (isValid)
                {
                    isValid = TrafficLightValidator.ValidateDurationsBetweenLanes(lanes);
                }
            }

            lanes[laneIndex].TrafficLight.SetLightDurations(newRedDuration, newYellowDuration, newGreenDuration);

            Console.WriteLine("Light durations updated successfully!");

            while (true)
            {
                Console.WriteLine($"Current Color: {lanes[laneIndex].TrafficLight.CurrentColor}");
                Console.Write("Enter the new current color (1-Red, 2-Green): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    lanes[laneIndex].TrafficLight.CurrentColor = LightColor.Red;
                    break;
                }
                else if (input == "2")
                {
                    lanes[laneIndex].TrafficLight.CurrentColor = LightColor.Green;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
            }
        }

        public void SimulationController()
        {
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Start simulation");
                Console.WriteLine("2. Change light durations");
                Console.WriteLine("3. Exit");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        bool isValidConfiguration = true;
                        int invalidCrossroadIndex = 0;

                        foreach (var crossroads in _trafficSimulator.Crossroads)
                        {
                            if (!TrafficLightValidator.ValidateDurationsBetweenLanes(crossroads.Lanes))
                            {
                                isValidConfiguration = false;
                                invalidCrossroadIndex = crossroads.Id;
                                break;
                            }
                        }

                        if (isValidConfiguration)
                        {
                            _trafficSimulator.Simulation();
                        }
                        else
                        {
                            Console.WriteLine($"Invalid intersection configuration in crossroad #{invalidCrossroadIndex}. Please change light durations first.");
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ChangeLightDurations();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}

