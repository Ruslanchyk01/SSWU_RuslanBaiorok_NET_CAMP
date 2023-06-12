// Вхідний масив
using Task1;

int[] array = { 3, 6, 9, 7, 5, 2, 8, 4, 1 };

Selector<int> pivotSelector = new Selector<int>();

// Використання різних варіантів вибору опорного елементу
Console.WriteLine("Перший елемент:");
QuickSorter<int> sorter = new QuickSorter<int>();
sorter.Sort(array, pivotSelector.ChooseFirstElement);
PrintArray(array);

Console.WriteLine("Довільний елемент:");
sorter.Sort(array, pivotSelector.ChooseRandomElement);
PrintArray(array);

Console.WriteLine("Медіана:");
sorter.Sort(array, pivotSelector.ChooseMedianElement);
PrintArray(array);

static void PrintArray<T>(T[] array)
{
    foreach (var element in array)
    {
        Console.Write(element + " ");
    }
    Console.WriteLine();
}