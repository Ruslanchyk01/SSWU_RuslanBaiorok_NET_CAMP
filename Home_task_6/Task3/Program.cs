using System;
using Task3;

Text text = new("Я люблю вивчати програмування. Програмування це круто! Ти любиш програмування? Я люблю також таке: читати, писати, говорити"); // не має вивести: Я, люблю, програмування
Console.Write("Unique words: ");
foreach (string word in text.GetUniqueWords())
{
    Console.Write($"{word}, ");
}
Console.WriteLine(text);