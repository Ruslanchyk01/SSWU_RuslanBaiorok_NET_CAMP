using System;
using Home_task_8.Objects;

namespace Home_task_8.Interfaces
{
    public interface ITrafficSimulator
    {
        List<Crossroad> Crossroads { get; }

        void Simulation();
    }

}

