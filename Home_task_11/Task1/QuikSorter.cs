using System;
namespace Task1
{
    class QuickSorter<T>
    {
        public delegate int Selector(T[] array, int low, int high);

        public void Sort(T[] array, Selector choosePivot)
        {
            Sort(array, 0, array.Length - 1, choosePivot);
        }

        private void Sort(T[] array, int low, int high, Selector choosePivot)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, choosePivot(array, low, high));
                Sort(array, low, pivotIndex - 1, choosePivot);
                Sort(array, pivotIndex + 1, high, choosePivot);
            }
        }

        private int Partition(T[] array, int low, int high, int pivotIndex)
        {
            T pivotValue = array[pivotIndex];
            Swap(array, pivotIndex, high);
            int left = low;

            for (int i = low; i < high; i++)
            {
                if (Comparer<T>.Default.Compare(array[i], pivotValue) <= 0)
                {
                    Swap(array, i, left);
                    left++;
                }
            }

            Swap(array, left, high);
            return left;
        }

        private void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

