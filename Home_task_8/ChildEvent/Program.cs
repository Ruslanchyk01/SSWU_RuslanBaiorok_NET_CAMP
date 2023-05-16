using System;
using ChildEvent;

Child child = new Child();

child.ParentEvent += ParentAndChild;
child.ChildMethod();

static void ParentAndChild()
{
    Console.WriteLine("Parent and Child");
}
