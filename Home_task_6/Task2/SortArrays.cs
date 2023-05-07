using System;
using System.Collections.Generic;

namespace Task2
{
	public class SortArrays
	{
        // сортування без об'єднання масивів у щось одне ціле
        public static IEnumerable<int> SortArraysWithoutMerging(params int[][] arrays)
        {// Можна без виділення останнього
            for (int a = 0; a < arrays.Length; a++)
            {
                bool isLastArray = (a == arrays.Length - 1);
                for (int i = 0; i < arrays[a].Length; i++)
                {
                    for (int b = a + 1; b < arrays.Length; b++)
                    {
                        for (int j = 0; j < arrays[b].Length; j++)
                        {
                            if (arrays[b][j] < arrays[a][i])
                            {
                                int temp = arrays[b][j];
                                arrays[b][j] = arrays[a][i];
                                arrays[a][i] = temp;
                            }
                        }
                    }
                    if (!isLastArray)
                    {
                        yield return arrays[a][i];
                    }
                }
                if (isLastArray)
                {
                    for (int i = arrays[a].Length - 1; i >= 0; i--)
                    {
                        yield return arrays[a][i];
                    }
                }
            }
        }

        // сортування з об'єднанням масивів
        public static IEnumerable<int> SortArraysWithMerging(params int[][] arrays)
        {
            SortedSet<int> sorted = new SortedSet<int>();
            foreach (int[] array in arrays)
            {
                foreach (int num in array)
                {
                    sorted.Add(num);
                }
            }
            foreach (int num in sorted)
            {
                yield return num;
            }
        }
    }
}

