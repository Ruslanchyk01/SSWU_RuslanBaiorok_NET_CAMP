using System;
using System.Text;

namespace Task1
{
    internal class Text
	{
		private readonly string _text;

		//public Text()
		//{
		//}

        public Text(string text)
        {
            _text = text;
        }

        private string[] GetWords(string text)
        {
            char[] delimiters = new char[] { ' ', '\n' };
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private List<string> SearchSentencesWithBrackets()
        {
            string[] words = GetWords(_text);

            List<string> sentences = new List<string>();
            StringBuilder currentSentence = new();

            foreach (string word in words)
            {
                currentSentence.Append(word).Append(" ");
                if (word.EndsWith(".") || word.EndsWith("!") || word.EndsWith("?"))
                {
                    if (currentSentence.ToString().Contains("(") && currentSentence.ToString().Contains(")"))
                    {
                        sentences.Add(currentSentence.ToString().TrimEnd());
                    }
                    currentSentence.Clear();
                }
            }
            return sentences;
        }

        public override string? ToString()
        {
            List<string> sentencesWithBrackets = SearchSentencesWithBrackets();
            StringBuilder sb = new();
            foreach (string sen in sentencesWithBrackets)
            {
                sb.Append(sen + "\n");
            }
            return sb.ToString();
        }
    }
}

