using System;
namespace Task2
{
    public class TextSorter
    {
        private const int MaxMemorySize = 50;

        public static void MergeSort(string filePath)
        {
            int[] numbers = ReadNumbersFromFile(filePath);

            Sort(numbers, 0, numbers.Length - 1);

            WriteNumbersToFile(numbers, filePath);
        }

        private static int[] ReadNumbersFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int[] numbers = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                if (!int.TryParse(lines[i], out int number))
                {
                    throw new FormatException($"Invalid number at line {i + 1}.");
                }

                numbers[i] = number;
            }

            return numbers;
        }

        private static void WriteNumbersToFile(int[] numbers, string filePath)
        {
            string[] lines = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                lines[i] = numbers[i].ToString();
            }

            File.WriteAllLines(filePath, lines);
        }

        private static void Sort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(numbers, left, middle);
                Sort(numbers, middle + 1, right);

                Merge(numbers, left, middle, right);
            }
        }

        private static void Merge(int[] numbers, int left, int middle, int right)
        {
            int[] temp = new int[MaxMemorySize];

            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            for (int i = 0; i < leftSize; i++)
            {
                leftArray[i] = numbers[left + i];
            }

            for (int i = 0; i < rightSize; i++)
            {
                rightArray[i] = numbers[middle + 1 + i];
            }

            int leftIndex = 0;
            int rightIndex = 0;
            int mergeIndex = left;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                {
                    numbers[mergeIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    numbers[mergeIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

                mergeIndex++;
            }

            while (leftIndex < leftSize)
            {
                numbers[mergeIndex] = leftArray[leftIndex];
                leftIndex++;
                mergeIndex++;
            }

            while (rightIndex < rightSize)
            {
                numbers[mergeIndex] = rightArray[rightIndex];
                rightIndex++;
                mergeIndex++;
            }
        }
    }
}

