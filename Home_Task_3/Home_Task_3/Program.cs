using Home_Task_3;

TextLine textLine = new TextLine("My name is Ruslan. Do I like programming? Programming is amazingly, programming extremely interesting!");
int? secondSubstringIndex = textLine.FindSecondSubstring("programming");
Console.WriteLine(secondSubstringIndex);

int upperWords = textLine.FindUpperWords();

Console.WriteLine(upperWords);

string DoublingLetters = textLine.ReplaceWordsWithDoublingLetters("reading");
Console.WriteLine(DoublingLetters);
