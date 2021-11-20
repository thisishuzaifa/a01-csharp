using System;
using System.IO;
using System.Globalization;

namespace AssignmentOne
{
    public class StoreData
    {
        public int storeNumber { get; set; }
        public string date { get; set; }
        public decimal weeklySales { get; set; }
        public int holidayFlag { get; set; }

        public StoreData(string line)
        {
            string[] rowData = line.Split(',');
            this.storeNumber = int.Parse(rowData[0]);
            this.date = DateTime.ParseExact(rowData[1], "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-yyyy");
            this.weeklySales = decimal.Parse(rowData[2]);
            this.holidayFlag = int.Parse(rowData[3]);
        }
    }
}
