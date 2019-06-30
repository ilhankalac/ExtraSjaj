using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraSjaj.Common.Models
{
    public class Statistika
    {
       

        //public Dictionary<int, double> TotalYearIncome { get; set; }
        //public Dictionary<int, double> MonthlyIncome { get; set; }

        public int Godina { get; set; }
        public double TotalYearIncome { get; set; }

        public List<Month> Months { get; set; }

    }
    public class Month
    {
        public int Mesec { get; set; }
        public double TotalMonthIncome { get; set; }
    }
}
