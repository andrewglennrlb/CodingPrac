using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Calculations
    {
        [Key]
        public Int64 CalculationId { get; set; }

         public String CalculationType { get; set; }

         public Decimal Amount { get; set; }

         public Int64 ForeignEntityId { get; set; }

            
         public Int64 ReportingPeriodId { get; set; }

            
         public String CalculationLineText { get; set; }

    }
}
