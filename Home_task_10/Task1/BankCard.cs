using System;
namespace Task1
{
	public class BankCard
	{
        public string CardType { get; private set; }
        public string CardNumber { get; private set; }

        public BankCard(string сard)
        {
            CardType = GetCardType(сard);
            CardNumber = GetCardNumber(сard);
        }

        private string GetCardType(string сard)
        {
            int start = сard.IndexOf("#") + 1;
            int end = сard.IndexOf("#", start);
            return сard.Substring(start, end - start).Trim();
        }

        private string GetCardNumber(string сard)
        {
            int start = сard.IndexOf("card_number = \"") + 15;
            int end = сard.LastIndexOf("\"");
            return сard.Substring(start, end - start);
        }
    }
}

