using System;
using Home_task_8.Enums;
using Home_task_8.Objects;

namespace Home_task_8
{
    public static class TrafficLightValidator
    {
        private const int MIN_RED_DURATION = 10;
        private const int MIN_YELLOW_DURATION = 1;
        private const int MIN_GREEN_DURATION = 5;

        public static bool ValidateDurations(int redDuration, int yellowDuration, int greenDuration)
        {
            if (redDuration < MIN_RED_DURATION || yellowDuration < MIN_YELLOW_DURATION|| greenDuration < MIN_GREEN_DURATION)
            {
                Console.WriteLine($"Red duration must be > {MIN_RED_DURATION}sec. Yellow duration must be > {MIN_YELLOW_DURATION}sec. Green duration must be > {MIN_GREEN_DURATION}sec.");
                return false;
            }

            return true;
        }

        public static bool ValidateDurationsBetweenLanes(List<Lane> lanes)
        {
            bool hasNorthSouthGreen = false;
            bool hasEastWestGreen = false;

            int maxGreenDurationNorthSouth = 0;
            int maxRedDurationNorthSouth = 0;
            int maxRedDurationEastWest = 0;
            int maxGreenDurationEastWest = 0;

            foreach (var lane in lanes)
            {
                if (lane.Direction == LaneDirection.North || lane.Direction == LaneDirection.South)
                {
                    if (lane.TrafficLight.GreenDuration > maxGreenDurationNorthSouth)
                    {
                        maxGreenDurationNorthSouth = lane.TrafficLight.GreenDuration;
                    }

                    if (lane.TrafficLight.RedDuration > maxRedDurationNorthSouth)
                    {
                        maxRedDurationNorthSouth = lane.TrafficLight.RedDuration;
                    }

                    if (lane.TrafficLight.CurrentColor == LightColor.Green)
                    {
                        hasNorthSouthGreen = true;
                    }
                }
                else if (lane.Direction == LaneDirection.East || lane.Direction == LaneDirection.West)
                {
                    if (lane.TrafficLight.GreenDuration > maxGreenDurationEastWest)
                    {
                        maxGreenDurationEastWest = lane.TrafficLight.GreenDuration;
                    }

                    if (lane.TrafficLight.RedDuration > maxRedDurationEastWest)
                    {
                        maxRedDurationEastWest = lane.TrafficLight.RedDuration;
                    }

                    if (lane.TrafficLight.CurrentColor == LightColor.Green)
                    {
                        hasEastWestGreen = true;
                    }
                }
            }

            if ((maxGreenDurationNorthSouth >= maxRedDurationEastWest || maxGreenDurationEastWest >= maxRedDurationNorthSouth)
                || (hasNorthSouthGreen && hasEastWestGreen))
            {
                Console.WriteLine("Invalid intersection configuration. North/South lanes cannot have longer green lights than East/West lanes have red lights, and East/West lanes cannot have longer green lights than North/South lanes have red lights. Also, green lights cannot be simultaneously active in North/South and East/West lanes.");
                return false;
            }

            return true;
        }

        public static void ValidateLanes(List<Lane> lanes)
        {
            bool hasNorthSouth = false;
            bool hasEastWest = false;

            foreach (var lane in lanes)
            {
                if (lane.Direction == LaneDirection.North || lane.Direction == LaneDirection.South)
                {
                    hasNorthSouth = true;
                }
                else if (lane.Direction == LaneDirection.East || lane.Direction == LaneDirection.West)
                {
                    hasEastWest = true;
                }

                if (hasNorthSouth && hasEastWest)
                {
                    break;
                }
            }

            if (!hasNorthSouth || !hasEastWest)
            {
                throw new ArgumentException("Invalid lane configuration. At least one North/South lane and one East/West lane are required.");
            }
        }


    }

}

