using System;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class CostCategory
    {
        [Key]
        public Int64 CostCategoryId { get; set; }


        public String StartDate { get; set; }


        public String EndDate { get; set; }


        public Decimal CurrentAmount { get; set; }


        public Int64 ParentCategoryId { get; set; }


        public Int64 ProjectId { get; set; }


        public Int64 HistoricalEntityId { get; set; }


        public Int64 CalculationId { get; set; }
    }
}
