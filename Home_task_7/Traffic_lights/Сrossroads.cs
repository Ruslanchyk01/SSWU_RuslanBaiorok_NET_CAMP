using System;
using System.Text;

namespace Traffic_lights
{
    public class Crossroads
    {
        private List<TrafficLight> _trafficLights;

        public Crossroads(List<TrafficLight> trafficLights)
        {
            _trafficLights = trafficLights;

            // підписка на івент для всіх світлофорів
            foreach (TrafficLight trafficLight in _trafficLights)
            {
                trafficLight.LightChanged += TrafficLightChanged;
            }
        }

        public override string? ToString()
        {
            StringBuilder sb = new();
            foreach (TrafficLight trafficLight in _trafficLights)
            {
                sb.Append($"{trafficLight}\n");
            }
            return sb.ToString();
        }

        // метод для івента, що сповіщатиме про зміну кольору
        private void TrafficLightChanged(TrafficLight trafficLight)
        {
            Console.WriteLine($"Traffic light {trafficLight.Name} switched to {trafficLight.CurrentColor}");
        }

        // метод для переключення і виводу кольорів всіх світлофорів
        private void UpdateTrafficLights()
        {
            string trafficLightsStatus = "Traffic lights colors: ";
            foreach (TrafficLight trafficLight in _trafficLights)
            {
                trafficLightsStatus += $"\n{trafficLight.Name} - {trafficLight.CurrentColor}";
            }
            Console.WriteLine($"{trafficLightsStatus}\n");

            foreach (TrafficLight trafficLight in _trafficLights)
            {
                trafficLight.SwitchColor();
            }
        }

        // метод для запуску симуляції роботи перехрестя
        public void Simulation()
        {
            Console.WriteLine("Simulating crossroads...");
            bool isRunning = true;

            while (isRunning)
            {
                UpdateTrafficLights();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key != ConsoleKey.Escape)
                    {
                        isRunning = false;
                        Console.WriteLine("Exiting simulation...");
                    }
                }
            }
        }

    }
}
