using System;
namespace Task3
{
	internal static class Menu
	{
        public static void ShowMenu()
        {
            string path = "";
            bool validPath = false;
            while (!validPath)
            {
                Console.WriteLine("Please enter the path to the folder:");
                path = Console.ReadLine();
                validPath = FileManager.ReadFolder(path);
                if (!validPath)
                {
                    Console.WriteLine("Invalid path. Please try again");
                }
            }

            FileManager.PrintFileNames();

            string fileName = "";
            bool validFile = false;
            while (!validFile)
            {
                Console.WriteLine("Please enter the name of the file:");
                fileName = Console.ReadLine();
                validFile = FileManager.ReadFile(fileName);
                if (!validFile)
                {
                    Console.WriteLine("Invalid file name. Please try again");
                }
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Print apartment data");
                Console.WriteLine("2. Print information about one apartment");
                Console.WriteLine("3. Print owner with max debt");
                Console.WriteLine("4. Print apartments without consume electricity");
                Console.WriteLine("5. Calculate amount of expenses for each apartment");
                Console.WriteLine("6. Print days since last electricity reading");
                Console.WriteLine("7. Exit program");

                int choice = 0;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);
                if (validChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            PrintInfo.PrintApartmentsInfoTable();
                            break;
                        case 2:
                            Console.WriteLine("Please enter the apartment number:");
                            int apartmentNumber = 0;
                            bool validApartmentNumber = int.TryParse(Console.ReadLine(), out apartmentNumber);
                            if (validApartmentNumber)
                            {
                                PrintInfo.PrintApartmentInfoOne(apartmentNumber);
                            }
                            else
                            {
                                Console.WriteLine("Invalid apartment number");
                            }
                            break;
                        case 3:
                            PrintInfo.PrintOwnerWithMaxDebt();
                            break;
                        case 4:
                            PrintInfo.PrintApartmentsWithoutСonsumeElectricity();
                            break;
                        case 5:
                            PrintInfo.CalculateAmountOfExpenses();
                            break;
                        case 6:
                            PrintInfo.CalculateMeterReadingsdaysAgo();
                            break;
                        case 7:
                            Console.WriteLine("Exit program");
                            return;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }
        }
    }
}

