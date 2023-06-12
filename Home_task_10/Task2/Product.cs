using System;
namespace Task2
{
    abstract class Product
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }

        protected Product(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract double Accept(IVisitor visitor);
    }
}

