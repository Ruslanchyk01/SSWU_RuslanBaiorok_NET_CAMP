using System;
using System.Text.RegularExpressions;

namespace Home_Task_3
{
	public class TextLine
	{
		private string _text;
		public TextLine(string text)
        {
            _text = text;
        }

        public int? FindSecondSubstring(string substring)
        {
            // шукаємо початковий індекс нашої підстрічки
            int firstSubstringIndex = _text.IndexOf(substring);


            // перевірка чи знайдено таке слово
            if (firstSubstringIndex != -1)
            {
                // пошук початкового індекса наступної такої самої підстрічки
                int secondSubstringIndex = _text.IndexOf(substring, firstSubstringIndex + substring.Length);

                // якщо таке є друге таке саме слово, то повертаємо його початковий індекс
                if (secondSubstringIndex != -1)
                {
                    return secondSubstringIndex;
                }
            }

            return null;
        }

        public int FindUpperWords()
        {
            // лічильник кількості слів з великої букви
            int count = 0;

            // розділяємо текст на окремі слова 
            string[] words = _text.Split(" ");

            // перебираємо наші слова
            foreach (string word in words)
            {
                // якщо знайдено слово з великої букви, збільшуємо лічильник на 1
                if (char.IsUpper(word[0]))
                {
                    count++;
                }
            }

            return count;
        }

        public string ReplaceWordsWithDoublingLetters(string substring)
        {
            // розділяємо текст на окремі слова та розділові знаки
            string[] words = Regex.Split(_text, @"(\W)");
             
            // перебираємо кожен елемент масива і замінюємо слова з подвоєнням літер
            for (int i = 0; i < words.Length; i++)
            {
                // якщо символ рівний розділовому знаку, то ми пропускаєм цикл
                if (!Regex.IsMatch(words[i], @"\w")) continue;

                //перебираємо букви кожного слова 
                for (int j = 1; j < words[i].Length; j++)
                {
                    // якщо є подвоєння букв, замінюємо на нашу підстрічку
                    if (words[i][j] == words[i][j - 1])
                    {
                        words[i] = substring;
                    }
                }
            }

            // збираємо усе знову в рядок та повертаємо замінений текст
            return string.Concat(words);
        }
    }
}

