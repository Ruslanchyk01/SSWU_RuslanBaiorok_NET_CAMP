using System;
using Task1;

Matrix<int> intMRX = new Matrix<int>(4);
Console.WriteLine(intMRX);
foreach (int i in intMRX)
{
    Console.Write($"{i}, ");
}

Console.WriteLine("\n");

Matrix<double> doubleMRX = new Matrix<double>(4);
Console.WriteLine(doubleMRX);
foreach (double d in doubleMRX)
{
    Console.Write($"{d}, ");
}

Console.WriteLine("\n");

Matrix<float> floatMRX = new Matrix<float>(4);
Console.WriteLine(floatMRX);
foreach (float f in floatMRX)
{
    Console.Write($"{f}, ");
}