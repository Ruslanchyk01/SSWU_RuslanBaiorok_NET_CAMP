using System;
namespace Task1
{
	public static class BankCardValidator
	{
        public static bool IsValidCardNumber(string cardNumber, string cardType)
        {
            switch (cardType)
            {
                case "American Express":
                    return IsAmericanExpressCardValid(cardNumber);
                case "MasterCard":
                    return IsMasterCardValid(cardNumber);
                case "Visa":
                    return IsVisaCardValid(cardNumber);
                default:
                    Console.WriteLine($"Невідомий тип картки: {cardType}");
                    return false;
            }
        }

        private static bool IsAmericanExpressCardValid(string cardNumber)
        {
            return cardNumber.Length == 15 && (cardNumber.StartsWith("34") || cardNumber.StartsWith("37"));
        }

        private static bool IsMasterCardValid(string cardNumber)
        {
            return cardNumber.Length == 16 && cardNumber.StartsWith("5") &&
                (cardNumber[1] >= '1' && cardNumber[1] <= '5');
        }

        private static bool IsVisaCardValid(string cardNumber)
        {
            int length = cardNumber.Length;
            return (length == 13 || length == 16) && cardNumber.StartsWith("4");
        }
    }
}

