using Home_task_8;
using Home_task_8.Enums;
using Home_task_8.Objects;

var trafficLight1 = new TrafficLight(10, 2, 5, LightColor.Green, false);
var lane1 = new Lane(LaneDirection.East, trafficLight1);

var trafficLight2 = new TrafficLight(10, 2, 5, LightColor.Red, true);
var lane2 = new Lane(LaneDirection.North, trafficLight2);

var trafficLight3 = new TrafficLight(10, 2, 5, LightColor.Green, true);
var lane3 = new Lane(LaneDirection.West, trafficLight3);

var trafficLight4 = new TrafficLight(10, 2, 5, LightColor.Red, true);
var lane4 = new Lane(LaneDirection.South, trafficLight4);

var crossroads1 = new Crossroad(new List<Lane> { lane1, lane2, lane3, lane4 });

var crossroads2 = new Crossroad(new List<Lane> { lane3, lane4 });

var TrafficSimulator = new TrafficSimulator(new List<Crossroad> { crossroads1, crossroads2 });

Controller controller = new Controller(TrafficSimulator);

controller.SimulationController();