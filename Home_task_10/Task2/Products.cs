using System;
namespace Task2
{
    class Products : Product
    {
        public bool IsPerishable { get; private set; }

        public Products(string name, double weight, bool isPerishable)
            : base(name, weight)
        {
            IsPerishable = isPerishable;
        }

        public override double Accept(IVisitor visitor)
        {
            return visitor.VisitProducts(this);
        }
    }
}

