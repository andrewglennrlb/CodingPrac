﻿//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html

using Dapper.Contrib.Extensions;

namespace DAL.Models
{

    public class PaymentApplication
    {
        [Key]
        public int PaymentApplicationId { get; set; }


        public int ContractId { get; set; }


        public string StartDate { get; set; }


        public string EndDate { get; set; }


        public int IssuedDate { get; set; }


        public decimal TotalPaid { get; set; }


        public decimal TotalClaimed { get; set; }


        public string PaidDate { get; set; }


        public string CurrentStatus { get; set; }


        public int HistoricalItemId { get; set; }


        public int ReportableItemId { get; set; }


        public int CalculationItemId { get; set; }

    }
}