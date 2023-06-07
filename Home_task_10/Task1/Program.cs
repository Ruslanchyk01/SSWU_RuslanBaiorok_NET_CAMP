using Task1;

BankCard card1 = new BankCard("# American Express # card_number = \"378282246310005\"");
BankCard card2 = new BankCard("# MasterCard # card_number = \"5555555555554444\"");
BankCard card3 = new BankCard("# Visa # card_number = \"4111111111111111\"");
BankCard card4 = new BankCard("# American Express # card_number = \"123456789012345\"");
BankCard card5 = new BankCard("# MasterCard # card_number = \"1234567890123456\"");
BankCard card6 = new BankCard("# Visas # card_number = \"12345678901234\"");

ValidateCard(card1);
ValidateCard(card2);
ValidateCard(card3);
ValidateCard(card4);
ValidateCard(card5);
ValidateCard(card6);

static void ValidateCard(BankCard card)
{
    if (BankCardValidator.IsValidCardNumber(card.CardNumber, card.CardType))
    {
        Console.WriteLine($"Номер картки {card.CardNumber} є коректним");
        Console.WriteLine($"Тип картки: {card.CardType}");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"Номер картки {card.CardNumber} є некоректним");
        Console.WriteLine();
    }
}