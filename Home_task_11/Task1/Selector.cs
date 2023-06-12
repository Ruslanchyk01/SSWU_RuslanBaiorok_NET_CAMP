using System;
namespace Task1
{
    class Selector<T>
    {
        public int ChooseFirstElement(T[] array, int low, int high)
        {
            return low;
        }

        public int ChooseRandomElement(T[] array, int low, int high)
        {
            Random random = new Random();
            return random.Next(low, high + 1);
        }

        public int ChooseMedianElement(T[] array, int low, int high)
        {
            int middle = (low + high) / 2;
            T[] tempArray = { array[low], array[middle], array[high] };
            Array.Sort(tempArray);
            if (tempArray[1].Equals(array[low]))
                return low;
            else if (tempArray[1].Equals(array[middle]))
                return middle;
            else
                return high;
        }
    }
}

