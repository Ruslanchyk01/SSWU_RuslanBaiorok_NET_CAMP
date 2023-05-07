using System;
namespace Traffic_lights
{
    class Controller : IController
    {
        private readonly List<TrafficLight> _trafficLights;
        private readonly Crossroads _crossroads;

        public Controller(List<TrafficLight> trafficLights, Crossroads crossroads)
        {
            _trafficLights = trafficLights;
            _crossroads = crossroads;
        }

        // Метод для зміни таймерів кольорів світлофорів
        private void ChangeLightDurations()
        {
            Console.WriteLine("Enter the new duration for each light color:");
            Console.Write($"Red: ");
            int newRedDuration = int.Parse(Console.ReadLine());
            Console.Write($"Yellow: ");
            int newYellowDuration = int.Parse(Console.ReadLine());
            Console.Write($"Green: ");
            int newGreenDuration = int.Parse(Console.ReadLine());

            // Зміна таймерів кольорів на всіх світлофорах
            foreach (TrafficLight trafficLight in _trafficLights)
            {
                trafficLight.SetLightDurations(newRedDuration, newYellowDuration, newGreenDuration);
            }

            Console.WriteLine("Light durations updated successfully!");
        }

        // Метод для запуску симуляції роботи перехрестя
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
                        _crossroads.Simulation();
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

