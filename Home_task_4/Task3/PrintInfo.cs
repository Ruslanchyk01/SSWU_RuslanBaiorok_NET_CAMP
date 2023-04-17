using System;
namespace Task3
{
	internal static class PrintInfo
	{
        public static List<Apartment> apartments = new List<Apartment>();

        public static void PrintApartmentsInfoTable()
        {
            if (apartments == null || apartments.Count == 0) return;

            string apartmentNumber = "APARTMENT NUMBER";
            string owner = "OWNER";
            string debt = "DEBT";

            int[] columnWidths = new int[6];
            foreach (var apartment in apartments)
            {
                columnWidths[0] = Math.Max(columnWidths[0], apartmentNumber.Length);
                columnWidths[1] = Math.Max(columnWidths[1], apartment.Owner.Length);
                columnWidths[2] = Math.Max(columnWidths[2], apartment.Dates[0].ToString("dd.MMMM.yy").Length);
                columnWidths[3] = Math.Max(columnWidths[3], apartment.Dates[1].ToString("dd.MMMM.yy").Length);
                columnWidths[4] = Math.Max(columnWidths[4], apartment.Dates[2].ToString("dd.MMMM.yy").Length);
                columnWidths[5] = Math.Max(columnWidths[5], apartment.Debt.ToString("C").Length - 1);
            }

            string mainHead = "Number of apartments: " + Apartment.NumberOfApartments + "; " + "Quarter number: " + Apartment.QuarterNumber;
            string head = "|" + apartmentNumber.PadRight(columnWidths[0]) + "|" + owner.PadRight(columnWidths[1]) + "|"
                + apartments[0].Dates[0].ToString("MMMM").ToUpper().PadRight(columnWidths[2]) + "|" + apartments[0].Dates[1].ToString("MMMM").ToUpper().PadRight(columnWidths[3]) + "|"
                + apartments[0].Dates[2].ToString("MMMM").ToUpper().PadRight(columnWidths[4]) + "|" + debt.PadRight(columnWidths[5]) + "|";

            string line = new string('-', head.Length);

            Console.WriteLine(mainHead);
            Console.WriteLine(line);
            Console.WriteLine(head);
            Console.WriteLine(line);

            foreach (var apartment in apartments)
            {
                string apartmentInfo = "|" + apartment.ApartmentNumber.ToString().PadRight(columnWidths[0]) + "|" + apartment.Owner.PadRight(columnWidths[1]) + "|"
                    + apartment.Dates[0].ToString("dd.MM.yy").PadRight(columnWidths[2]) + "|" + apartment.Dates[1].ToString("dd.MM.yy").PadRight(columnWidths[3]) + "|"
                    + apartment.Dates[2].ToString("dd.MM.yy").PadRight(columnWidths[4]) + "|" + apartment.Debt.ToString("C").PadRight(columnWidths[5]) + "|";
                Console.WriteLine(apartmentInfo);
            }
            Console.WriteLine(line);
        }

        public static void PrintApartmentInfoOne(int apartmentNumber)
        {
            var apartment = apartments.FirstOrDefault(a => a.ApartmentNumber == apartmentNumber);

            if (apartment == null)
            {
                Console.WriteLine($"Apartment {apartmentNumber} not found");
                return;
            }
            Console.WriteLine(apartment);
        }

        public static void PrintOwnerWithMaxDebt()
        {
            if (apartments == null || apartments.Count == 0) return;

            decimal maxDebt = 0;
            string ownerWithMaxDebt = "";

            foreach (var apartment in apartments)
            {
                decimal debt = apartment.Debt;

                if (debt > maxDebt)
                {
                    maxDebt = debt;
                    ownerWithMaxDebt = apartment.Owner;
                }
            }
            Console.WriteLine($"Owner with max debt: {ownerWithMaxDebt}; Debt amount: {maxDebt:C}");
        }

        public static void PrintApartmentsWithoutСonsumeElectricity()
        {
            bool found = false;
            foreach (var apartment in apartments)
            {
                if (apartment.ElectricityСonsumed[0] == apartment.ElectricityСonsumed[1])
                {
                    Console.WriteLine($"Apartment {apartment.ApartmentNumber} did not consume electricity");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("All apartments consumed electricity");
            }
        }

        public static void CalculateAmountOfExpenses()
        {
            if (apartments == null || apartments.Count == 0) return;

            foreach (var apartment in apartments)
            {
                int usedKWh = apartment.ElectricityСonsumed[1] - apartment.ElectricityСonsumed[0];
                decimal amountOfCosts = usedKWh * Apartment.CostPerKWH;
                Console.WriteLine($"Amount of costs: {amountOfCosts:C} for apartment {apartment.ApartmentNumber}");
            }
        }

        public static void CalculateMeterReadingsdaysAgo()
        {
            if (apartments == null || apartments.Count == 0) return;

            foreach (var apartment in apartments)
            {
                DateTime lastDayMeterReadings = apartment.Dates.Last().Date;
                int meterReadingsdaysAgo = (DateTime.Now - lastDayMeterReadings).Days;
                Console.WriteLine($"Apartment {apartment.ApartmentNumber}: meter readings were taken {meterReadingsdaysAgo} days ago");
            }
        }
    }
}

