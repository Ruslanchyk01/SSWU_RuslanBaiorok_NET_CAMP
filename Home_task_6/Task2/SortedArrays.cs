using System;
namespace Task2
{
	public class SortedArrays
	{
        // Потребує довершення
        public static IEnumerable<int> SortArraysWithoutMerging(params int[][] arrays)
        {
            for (int a = 0; a < arrays.Length; a++)
            {
                int[] array = arrays[a];
                for (int i = 0; i < array.Length; i++)
                {
                    for (int b = 0; b < arrays.Length; b++)
                    {
                        if (a == b) continue;
                        int[] otherArray = arrays[b];
                        for (int j = 0; j < otherArray.Length; j++)
                        {
                            if (otherArray[j] < array[i])
                            {
                                int temp = otherArray[j];
                                otherArray[j] = array[i];
                                array[i] = temp;
                            }
                        }
                    }
                    yield return array[i];
                }
            }
        }

        public static IEnumerable<int> SortArraysWithMerging(params int[][] arrays)
        {
            List<int> allArrayNumbers = new List<int>();
            foreach (int[] array in arrays)
            {
                allArrayNumbers.AddRange(array);
            }
            allArrayNumbers.Sort();

            foreach (int num in allArrayNumbers)
            {
                yield return num;
            }
        }
    }
}

