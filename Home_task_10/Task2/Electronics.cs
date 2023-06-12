using System;
namespace Task2
{
    class Electronics : Product
    {
        public double SizeInCentimeters { get; private set; }
        public double Price { get; private set; }

        public Electronics(string name, double weight, double sizeInCentimeters, double price)
            : base(name, weight)
        {
            SizeInCentimeters = sizeInCentimeters;
            Price = price;
        }

        public override double Accept(IVisitor visitor)
        {
            return visitor.VisitElectronics(this);
        }
    }
}

