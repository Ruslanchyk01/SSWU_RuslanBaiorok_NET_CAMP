using System;
namespace Task2
{
    class ShippingCost : IVisitor
    {
        private const double PRODUCTS_BASE_COST_PER_WEIGHT = 0.5;
        private const double PRODUCTS_URGENCY_COST = 2;
        private const double ELECTRONICS_BASE_COST_PER_WEIGHT = 2;
        private const double ELECTRONICS_OVERSIZE_PERCENTAGE = 0.1;
        private const double CLOTHES_BASE_COST_PER_WEIGHT = 0.4;

        public double VisitProducts(Products product)
        {
            double baseCost = product.Weight * PRODUCTS_BASE_COST_PER_WEIGHT;
            if (product.IsPerishable)
            {
                baseCost += PRODUCTS_URGENCY_COST;
            }
            return baseCost;
        }

        public double VisitElectronics(Electronics product)
        {
            double baseCost = product.Weight * ELECTRONICS_BASE_COST_PER_WEIGHT;
            if (product.SizeInCentimeters > 50)
            {
                double oversizeCost = product.Price * ELECTRONICS_OVERSIZE_PERCENTAGE;
                baseCost += oversizeCost;
            }
            return baseCost;
        }

        public double VisitСlothes(Сlothes product)
        {
            double baseCost = product.Weight * CLOTHES_BASE_COST_PER_WEIGHT;
            double sizeCost = GetClothingSizeCost(product.Size);
            baseCost += sizeCost;
            return baseCost;
        }

        private double GetClothingSizeCost(СlothesSize size)
        {
            switch (size)
            {
                case СlothesSize.XS:
                    return 0.1;
                case СlothesSize.S:
                    return 0.2;
                case СlothesSize.M:
                    return 0.3;
                case СlothesSize.L:
                    return 0.4;
                case СlothesSize.XL:
                    return 0.5;
                default:
                    return 0.0;
            }
        }
    }
}

