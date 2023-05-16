using System;
namespace ChildEvent
{
	public class Child : Parent
	{
        public void ChildMethod()
        {
            Console.WriteLine("Child");

            ParentMethod();
        }
    }
}

