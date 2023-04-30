using System;
namespace Task3
{
	public class Text
	{
        public static IEnumerable<string> GetUniqueWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
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

