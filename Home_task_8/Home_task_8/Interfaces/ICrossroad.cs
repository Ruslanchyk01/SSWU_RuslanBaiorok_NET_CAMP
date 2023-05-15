using System;
using Home_task_8.Objects;

namespace Home_task_8.Interfaces
{
    public interface ICrossroad
    {
        int Id { get; }
        List<Lane> Lanes { get; }
    }
}

