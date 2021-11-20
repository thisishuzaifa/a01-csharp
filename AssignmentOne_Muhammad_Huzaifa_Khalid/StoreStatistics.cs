using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static AssignmentOne.StoreData;

namespace AssignmentOne
{
    public class StoreStatistics
    {

        //Reading file from directory - please change root user when you download this project
        private const string FILE_PATH = "/Users/huzaifa/Desktop/AssignmentOne_Muhammad_Huzaifa_Khalid/Walmart_Store_Data.csv";
        private List<StoreData> storeData = new List<StoreData>();
        private List<int> storeRange = new List<int>();
        private List<string> monthRange = new List<string>();

        //Defining variables 
        public decimal individualWeeklySales = 0;
        public decimal individualHolidaySales = 0;
        public decimal individualMonthlySales = 0;
        public decimal alllWeeklySales = 0;
        public decimal allHolidaySales = 0;
        public decimal allMonthlySales = 0;

        //Initializing all variables
        public StoreStatistics()
        {
            this.storeData = File.ReadAllLines(FILE_PATH).Skip(1)
                    .Select(line => new StoreData(line)).ToList();
            this.alllWeeklySales = SumWeeklySales(this.storeData);
            this.allHolidaySales = SumHolidaySales(this.storeData);
        }

        // Input format is month-year i.e. MM-YYY
        public StoreStatistics(string mmYYYY)
        {
            // Only get data of chosen month
            this.storeData = File.ReadAllLines(FILE_PATH).Skip(1)
                    .Select(line => new StoreData(line)).Where(line => line.date == mmYYYY).ToList();
            this.individualMonthlySales = SumWeeklySales(storeData);
            this.allMonthlySales = SumWeeklySales(storeData);
        }

        public StoreStatistics(int storeNumber)
        {
            // Only get data of chosen store
            this.storeData = File.ReadAllLines(FILE_PATH).Skip(1)
                .Select(line => new StoreData(line)).Where(line => line.storeNumber == storeNumber).ToList();

            this.individualWeeklySales = SumWeeklySales(this.storeData);
            this.individualHolidaySales = SumHolidaySales(this.storeData);
        }
        //This function checks if the store number entered is in range
        public bool CheckStoreNum(int number)
        {
            this.storeRange = File.ReadAllLines(FILE_PATH).Skip(1)
                .Select(line => new StoreData(line).storeNumber).ToList();
            return storeRange.Contains(number);
        }
        //This function checks for appropriate date range.
        public bool CheckMonth(string month)
        {
            this.monthRange = File.ReadAllLines(FILE_PATH).Skip(1)
                .Select(line => new StoreData(line).date).ToList();
            return monthRange.Contains(month);
        }

        private decimal SumWeeklySales(List<StoreData> storeData)
        {
            return storeData.Sum(line => line.weeklySales);
        }

        private decimal SumHolidaySales(List<StoreData> storeData)
        {
            return storeData.Where(line => line.holidayFlag == 1).Sum(line => line.weeklySales);
        }
    }
}
