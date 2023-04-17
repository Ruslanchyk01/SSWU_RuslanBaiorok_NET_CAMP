using Task1;

Text textUrk = new("        Це речення (з дужками, яке ми розбиваємо     на окремі слова!   \n А    може бути, що між (словами були      декілька)   \n    пробілів.      А    може бути, що між (словами були     декілька).   ");
Text textEng = new("    This is a sentence (with parentheses), which we break into separate words! \n Or maybe there were several \n spaces between (words). Or maybe there were several (some   words).    ");
//List<string> sentencesWithBrackets = text.SearchSentencesWithBrackets();

//foreach(string sen in sentencesWithBrackets)
//{
//    Console.WriteLine(sen);
//}
Console.WriteLine(textUrk);
Console.WriteLine(textEng);