using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task3
{
    internal static class FileManager
    {
        private static string? _folderPath;
        private static List<string> _fileNames = new List<string>();

        public static bool ReadFolder(string folderPath)
        {
            _folderPath = folderPath;
            if (Directory.Exists(_folderPath))
            {
                string[] files = Directory.GetFiles(_folderPath, "*.txt");
                foreach (string file in files)
                {
                    _fileNames.Add(Path.GetFileName(file));
                }
                return true;
            }
            else
            {
                Console.WriteLine($"Folder '{_folderPath}' does not exist. Please try again");
                return false;
            }
        }

        public static void PrintFileNames()
        {
            if (_fileNames == null || _fileNames.Count == 0) return;

            Console.WriteLine("Files in folder:");

            foreach (string fileName in _fileNames)
            {
                Console.WriteLine(fileName);
            }
        }

        public static bool ReadFile(string fileName)
        {
            string path = Path.Combine(_folderPath, fileName);

            if (!File.Exists(path))
            {
                Console.WriteLine($"File '{fileName}' does not exist");
                return false;
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0)
            {
                Console.WriteLine($"File '{fileName}' is empty");
                return false;
            }

            string headLine = lines[0];
            string[] apartmentLine = headLine.Split(';');
            if (!headLine.StartsWith("Number of apartments:"))
            {
                Console.WriteLine($"Invalid format in file '{fileName}'");
                return false;
            }

            int numberOfApartments;
            if (!int.TryParse(apartmentLine[0].Split(':')[1].Trim(), out numberOfApartments))
            {
                Console.WriteLine($"Invalid format for number of apartments in file '{fileName}'");
                return false;
            }

            int quarterNumber;
            if (!int.TryParse(apartmentLine[1].Split(':')[1].Trim(), out quarterNumber))
            {
                Console.WriteLine($"Invalid format for quarter number in file '{fileName}'");
                return false;
            }

            Apartment.NumberOfApartments = numberOfApartments;
            Apartment.QuarterNumber = quarterNumber;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] apartmentInfo = lines[i].Split(';');
                if (apartmentInfo.Length != 6)
                {
                    Console.WriteLine($"Invalid format for apartment in file '{fileName}'");
                    continue;
                }

                int apartmentNumber;
                if (!int.TryParse(apartmentInfo[1].Split(':')[1], out apartmentNumber))
                {
                    Console.WriteLine($"Invalid format for apartment number in file '{fileName}'");
                    continue;
                }

                decimal paid;
                if (!decimal.TryParse(apartmentInfo[4].Split(':')[1], out paid))
                {
                    Console.WriteLine($"Invalid format for paid in file '{fileName}'");
                    continue;
                }

                string address = apartmentInfo[0].Split(':')[1].Trim();

                string owner = apartmentInfo[2].Split(':')[1].Trim();

                string[] electricityСonsumedStrings = apartmentInfo[3].Split(':')[1].Split('-');
                int[] electricityСonsumed = new int[electricityСonsumedStrings.Length];
                if (electricityСonsumedStrings.Length != 2
                    || !int.TryParse(electricityСonsumedStrings[0].Trim(), out int firstReading) || !int.TryParse(electricityСonsumedStrings[1].Trim(), out int secondReading)
                    || firstReading < 100000 || firstReading > 999999 || secondReading < 100000 || secondReading > 999999)
                {
                    Console.WriteLine($"Invalid format for electricity consumed in file '{fileName}'");
                    continue;
                }
                electricityСonsumed[0] = firstReading;
                electricityСonsumed[1] = secondReading;

                string[] dateStrings = apartmentInfo[5].Split(':')[1].Split('-');
                DateTime[] dates = new DateTime[dateStrings.Length];
                for (int j = 0; j < dateStrings.Length; j++)
                {
                    if (!DateTime.TryParseExact(dateStrings[j].Trim(), "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                    {
                        Console.WriteLine($"Invalid format for date in file '{fileName}'");
                        continue;
                    }
                    dates[j] = date;
                }

                PrintInfo.apartments.Add(new Apartment(address, apartmentNumber, owner, electricityСonsumed, paid, dates));
            }
            return true;
        }
    }

}

