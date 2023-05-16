using Home_task_8;
using Home_task_8.Enums;
using Home_task_8.Interfaces;
using Home_task_8.Objects;

TrafficLight trafficLight1 = new(10, 2, 5, LightColor.Green, false);
Lane lane1 = new(LaneDirection.East, trafficLight1);

TrafficLight trafficLight2 = new(10, 2, 5, LightColor.Red, true);
Lane lane2 = new(LaneDirection.North, trafficLight2);

TrafficLight trafficLight3 = new(10, 2, 5, LightColor.Green, true);
Lane lane3 = new(LaneDirection.West, trafficLight3);

TrafficLight trafficLight4 = new(10, 2, 5, LightColor.Red, true);
Lane lane4 = new(LaneDirection.South, trafficLight4);

TrafficLight trafficLight5 = new(10, 2, 5, LightColor.Green, true);
Lane lane5 = new(LaneDirection.West, trafficLight5);

TrafficLight trafficLight6 = new(10, 2, 5, LightColor.Red, true);
Lane lane6 = new(LaneDirection.South, trafficLight6);

Crossroad crossroads1 = new(new List<Lane> { lane1, lane2, lane3, lane4 });

Crossroad crossroads2 = new(new List<Lane> { lane5, lane6 });

TrafficSimulator trafficSimulator = new(new List<Crossroad> { crossroads1, crossroads2 });

Controller controller = new Controller(trafficSimulator);

controller.SimulationController();