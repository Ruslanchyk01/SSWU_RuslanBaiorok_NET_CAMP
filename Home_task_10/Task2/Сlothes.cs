using System;
namespace Task2
{
    class Сlothes : Product
    {
        public СlothesSize Size { get; private set; }

        public Сlothes(string name, double weight, СlothesSize size)
            : base(name, weight)
        {
            Size = size;
        }

        public override double Accept(IVisitor visitor)
        {
            return visitor.VisitСlothes(this);
        }
    }
}

