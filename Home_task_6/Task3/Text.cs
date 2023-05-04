using System;
namespace Task3
{// Все добре. Сумарний бал - 95.
	public class Text
	{
        private readonly string _text;

        public Text(string text)
        {
            _text = text;
        }

        public IEnumerable<string> GetUniqueWords()
        {
            string[] words = _text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
          
		for (int i = 0; i < words.Length; i++)
            {
                bool noRepeating = true;
                for (int j = 0; j < words.Length; j++)
                {
                    if (i != j && words[i] == words[j])
                    {
                        noRepeating = false;
                        break;
                    }
                }

                if (noRepeating)
                {
                    yield return words[i];
                }
            }
        }

    }
}

