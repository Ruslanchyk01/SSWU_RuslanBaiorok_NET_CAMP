using System;
using System.Text;

namespace Task2
{
    internal class EmailCheker
	{
		private string _text;

        public EmailCheker(string text)
		{
			_text = text;
        }

        public (List<string> validEmails, List<string> invalidLexemes) FindEmails()
        {
            var validEmails = new List<string>();
            var invalidLexemes = new List<string>();
            // Розділити текст на окремі слова
            string[] words = _text.Split(new char[] { ' ', ',', ';', ':', '\t', '\n'});

            // Перевірити кожне слово
            foreach (string word in words)
            {
                if (word.Contains("@"))
                {
                    string[] parts = word.Split('@');

                    if (parts.Length == 2 && IsValidLocalPart(parts[0]) && IsValidDomain(parts[1]))
                        validEmails.Add(word);
                    else
                        invalidLexemes.Add(word);
                }
            }

            return (validEmails, invalidLexemes);
        }

        private bool IsValidLocalPart(string localPart)
        {
            if (string.IsNullOrEmpty(localPart))
            {
                return false;
            }

            if (localPart.Length > 64)
            {
                return false;
            }

            bool quoted = false;
            int countBrackets = 0;
            int countQuotes = 0;
            for (int i = 0; i < localPart.Length; i++)
            {
                char c = localPart[i];

                if (c == '(')
                {
                    countBrackets++;
                    if (countBrackets == 2)
                    {
                        quoted = true;
                        break;
                    }
                }
                else if (c == ')')
                {
                    countBrackets++;
                    if (countBrackets == 2)
                    {
                        quoted = true;
                        break;
                    }
                }
                else if (c == '"')
                {
                    countQuotes++;
                    if (countQuotes == 2)
                    {
                        quoted = true;
                        break;
                    }
                }
                else if (quoted)
                {
                    if (c == '\\' && i < localPart.Length - 1)
                    {
                        i++;
                    }
                    else if (c >= 33 && c <= 126)
                    {
                        return false;
                    }

                    return true;
                }
                else if (!IsAllowedUnquotedChar(c, i, localPart))
                {
                    return false;
                }
            }


            return true;
        }

        private bool IsAllowedUnquotedChar(char c, int index, string localPart)
        {
            if (c >= 'a' && c <= 'z')
            {
                return true;
            }

            if (c >= 'A' && c <= 'Z')
            {
                return true;
            }

            if (c >= '0' && c <= '9')
            {
                return true;
            }

            if (c == '!' || c == '#' || c == '$' || c == '%' || c == '^' || c == '&' || c == '*' || c == '-' || c == '_' ||
                c == '=' || c == '+' || c == '{' || c == '}' || c == '|' || c == '\'' ||c == '/' || c == '?' || c == '`' ||
                c == '~')
            {
                return true;
            }

            if (c == '.')
            {
                if (index == 0 || index == localPart.Length - 1)
                {
                    return false;
                }

                bool inQuotes = false;
                for (int i = 0; i < index; i++)
                {
                    if (localPart[i] == '"')
                    {
                        inQuotes = !inQuotes;
                    }
                }

                if (!inQuotes && (localPart[index - 1] == '.' || localPart[index + 1] == '.'))
                {
                    return false;
                }

                return true;
            }


            return false;
        }

        private bool IsAllowedQuotedChar(char c)
        {
            if (c >= 33 && c <= 126)
            {
                return true;
            }

            return false;
        }

        private bool IsValidDomain(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return false;
            }
            if (domain.Length > 255)
            {
                return false;
            }
            if (domain[0] == '.' || domain[domain.Length - 1] == '.')
            {
                return false;
            }
            string[] labels = domain.Split('.');
            foreach (string label in labels)
            {
                if (label.Length > 63)
                {
                    return false;
                }
                foreach (char c in label)
                {
                    if (c == '(' || c == ')')
                    {
                        int firstIndex = label.IndexOf(c);
                        int lastIndex = label.LastIndexOf(c);
                        if (firstIndex != lastIndex)
                        {
                            return true;
                        }
                    }
                    else if (!((c >= 'A' && c <= 'Z')
                        || (c >= 'a' && c <= 'z')
                        || (c >= '0' && c <= '9')
                        || c == '-'))
                    {
                        return false;
                    }
                }
                if (label[0] == '-' || label[label.Length - 1] == '-')
                {
                    return false;
                }
            }
            return true;
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();

            List<string> valid = FindEmails().validEmails;
            List<string> invalid = FindEmails().invalidLexemes;

            sb.AppendLine("Валідні пошти");
            foreach (var val in valid)
            {
                sb.AppendLine(val);
            }

            sb.AppendLine(new string('-', 50));

            sb.AppendLine("Не валідні пошти");
            foreach (var val in invalid)
            {
                sb.AppendLine(val);
            }

            return sb.ToString();
        }
    }
}

