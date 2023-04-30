using System;
using Task2;

int[] array1 = { 1, 9, 3 };
int[] array2 = { 7, 6, 4 };
int[] array3 = { 2, 8, 5 };

foreach (int num in SortedArrays.SortArraysWithoutMerging(array1, array2, array3))
{
    Console.Write($"{num}, ");
}

Console.WriteLine();

foreach (int num in SortedArrays.SortArraysWithMerging(array1, array2, array3))
{
    Console.Write($"{num}, ");
}

