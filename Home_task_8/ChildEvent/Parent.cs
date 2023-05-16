using System;
namespace ChildEvent
{
    public delegate void ParentDelegate();

    public class Parent
	{
        public event ParentDelegate ParentEvent;

        public void ParentMethod()
        {
            Console.WriteLine("Parent");

            ParentEvent?.Invoke();
        }
    }
}

