using System;
using Task3;

string text = "Я люблю вивчати програмування. Програмування це круто! Ти любиш програмування? Я люблю також таке: читати, писати, говорити"; // не має вивести: Я, люблю, програмування
Console.WriteLine("Unique words:");
foreach (string word in Text.GetUniqueWords(text))
{
    Console.Write($"{word}, ");
}