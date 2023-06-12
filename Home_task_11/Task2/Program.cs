using System.Globalization;
using Task2;

string filePath = "input.txt";

try
{
    TextSorter.MergeSort(filePath);
    Console.WriteLine("Sorting completed successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
