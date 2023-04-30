using System;
using Task2;

int[] array1 = { 7, 9, 12 };
int[] array2 = { 1, 6, 4 };
int[] array3 = { 11, 8, 5 };
int[] array4 = { 2, 10, 3 };

foreach (int num in SortArrays.SortArraysWithoutMerging(array1, array2, array3, array4))
{
    Console.Write($"{num}, ");
}

Console.WriteLine();

foreach (int num in SortArrays.SortArraysWithMerging(array1, array2, array3, array4))
{
    Console.Write($"{num}, ");
}

