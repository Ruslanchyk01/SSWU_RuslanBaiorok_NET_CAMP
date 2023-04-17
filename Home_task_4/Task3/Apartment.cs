using System;
using System.Text;

namespace Task3
{
    internal class Apartment
    {
        private const decimal COST_PER_KWH = 1.68M;

        private readonly int _apartmentNumber;
        private readonly string _address;
        private readonly string _owner;
        private readonly int[] _electricityСonsumed;
        private readonly DateTime[] _dates;
        private readonly decimal _paid;

        public static decimal CostPerKWH { get => COST_PER_KWH; }
        public static int NumberOfApartments { get; set; }
        public static int QuarterNumber { get; set; }

        public int ApartmentNumber { get => _apartmentNumber; }
        public string Address { get => _address; }
        public string Owner { get => _owner; }
        public int[] ElectricityСonsumed { get => _electricityСonsumed; }
        public DateTime[] Dates { get => _dates; }
        public decimal Paid { get => _paid; }
        public decimal Debt { get => CalculateDebt(); }

        public Apartment(string address, int apartmentNumber, string owner, int[] electricityСonsumed, decimal paid, DateTime[] dates)
        {
            _address = address;
            _apartmentNumber = apartmentNumber;
            _owner = owner;
            _electricityСonsumed = electricityСonsumed;
            _paid = paid;
            _dates = dates;
        }
        private decimal CalculateDebt()
        {
            return (_electricityСonsumed[1] - _electricityСonsumed[0]) * COST_PER_KWH - _paid;
        }

        public override string? ToString()
        {
            return $"Address: {_address}; Apartment Number: {_apartmentNumber}; Owner: {_owner}; Electricity Сonsumed: {string.Join(" - ", _electricityСonsumed)}; Dates: {_dates[0].ToString("dd.MM.yy")} - {_dates[1].ToString("dd.MM.yy")} - {_dates[2].ToString("dd.MM.yy")}; Paid: {_paid.ToString("C")}; Debt: {CalculateDebt().ToString("C")};\n";
        }
    }

}

