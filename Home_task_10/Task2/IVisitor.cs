using System;
namespace Task2
{
    interface IVisitor
    {
        double VisitProducts(Products product);
        double VisitElectronics(Electronics product);
        double VisitСlothes(Сlothes product);
    }
}

