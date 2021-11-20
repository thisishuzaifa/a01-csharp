using System;
using System.Text.RegularExpressions;
using static AssignmentOne.StoreStatistics;

namespace AssignmentOne
{
    public class Menu
    {
        private int storeNumber;
        private string month;
        private bool isIndividualStore = false;

        public Menu()
        {
            MainMenu();
        }

        private void ConsoleHeader()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*          WALMART SALES MANAGER          *");
            Console.WriteLine("*******************************************\n");
            Console.WriteLine();
        }

        private void MainMenu()
        {
            Console.Clear();
            ConsoleHeader();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Individual Store Statistics");
            Console.WriteLine("2. All Stores Combined Statistics");
            Console.WriteLine("3. Quit");
            Console.Write("Please enter your selection:\t");
            int option = int.Parse(Console.ReadLine());
            
            switch (option)
            {
                case 1:
                    this.isIndividualStore = true;
                    StoreSelectionDisplay();
                    StoreMenu();
                    break;
                case 2:
                    this.isIndividualStore = false;
                    StoreMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid entry. Please try again! ");
                    break;
            }
        }

        private void StoreSelectionDisplay()
        {
            Console.Clear();
            ConsoleHeader();
            Console.Write("Please enter store number:\t");
            this.storeNumber = int.Parse(Console.ReadLine());
            StoreStatistics stats = new StoreStatistics();
            if (stats.CheckStoreNum(this.storeNumber))
            {
                StoreMenu();
            }
            else
            {
                Console.WriteLine($"Store {this.storeNumber} does not exists. Please try again");
                StoreSelectionDisplay();
            }
            
        }

        private void SubMenu()
        {
            Console.Clear();
            ConsoleHeader();
            if (this.isIndividualStore)
            {
                Console.WriteLine("STORE NUMBER: " + this.storeNumber);
                Console.WriteLine("1. Get total sales");
                Console.WriteLine("2. Enter total monthly sales");
                Console.WriteLine("3. Get holiday sales");
                Console.WriteLine("4. Return to main");
            }
            else
            {
                Console.WriteLine("ALL STORES");
                Console.WriteLine("1. Get total sales");
                Console.WriteLine("2. Enter total monthly sales");
                Console.WriteLine("3. Get holiday sales");
                Console.WriteLine("4. Return to main");
            }

        }

        private void ReturnMenu()
        {
            Console.WriteLine("\t Press RETURN to continue.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                StoreMenu();
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
                ReturnMenu();
            }
        }
        
        private void TotalSalesDisplay()
        {
            if (this.isIndividualStore)
            {
                StoreStatistics storeStatistics = new StoreStatistics(this.storeNumber);
                Console.WriteLine();
                Console.WriteLine($"\t Total Sales at Store #{this.storeNumber}:\t$" + 
                    String.Format("{0:n}", storeStatistics.individualWeeklySales));
            }
            else
            {
                StoreStatistics storeStatistics = new StoreStatistics();
                Console.WriteLine();
                Console.WriteLine($"\t Total Sales for All Stores:\t$" +
                    String.Format("{0:n}", storeStatistics.alllWeeklySales));
            }
        }
        
        private void MonthlySalesDisplay()
        {
            Console.Write("Please enter month and year in the format MM-YYYY:\t");
            this.month = Console.ReadLine().ToString();
            Regex format =  new Regex(@"^\d{2}-\d{4}$");
            StoreStatistics stats = new StoreStatistics();
            if (format.IsMatch(this.month) && stats.CheckMonth(this.month))
            {
                if (this.isIndividualStore)
                    {
                        StoreStatistics storeStatistics = new StoreStatistics(this.storeNumber);
                        Console.WriteLine();
                        Console.WriteLine($"\t Total Sales during {this.month} at Store #{this.storeNumber}:\t$" + 
                            String.Format("{0:n}", storeStatistics.individualWeeklySales));
                    }
                    else
                    {
                        StoreStatistics storeStatistics = new StoreStatistics();
                        Console.WriteLine();
                        Console.WriteLine($"\t Total Sales during {this.month} for All Stores:\t$" +
                            String.Format("{0:n}", storeStatistics.alllWeeklySales));
                    }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
                MonthlySalesDisplay();
            }
        }
        
        private void HolidaySalesDisplay()
        {
            if (this.isIndividualStore)
            {
                StoreStatistics storeStatistics = new StoreStatistics(this.storeNumber);
                Console.WriteLine();
                Console.WriteLine($"\t Total Holiday Sales at Store #{this.storeNumber}:\t$" + 
                    String.Format("{0:n}", storeStatistics.individualHolidaySales));
            }
            else
            {
                StoreStatistics storeStatistics = new StoreStatistics();
                Console.WriteLine();
                Console.WriteLine($"\t Total Holiday Sales for All Stores:\t$" + 
                    String.Format("{0:n}", storeStatistics.allHolidaySales));
            }
        }

        private void StoreMenu()
        {
            Console.Clear();
            SubMenu();
            Console.Write("Please enter your selection:\t");
            int selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    TotalSalesDisplay();
                    ReturnMenu();
                    break;
                case 2:
                    MonthlySalesDisplay();
                    ReturnMenu();
                    break;
                case 3:
                    HolidaySalesDisplay();
                    ReturnMenu();
                    break;
                case 4:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid entry. Please try again!");
                    StoreMenu();
                    break;
            }
        }
    }
}
