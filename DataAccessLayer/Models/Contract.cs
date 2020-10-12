using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Contract
    {
        [Key]
        public Int64 ContractId { get; set; }

        
        public String ContractDescription { get; set; }

        
        public Int64 ReportingPeriodId { get; set; }

        
        public Int64 HistoricalEntityId { get; set; }

        
        public Decimal CurrentAmount { get; set; }

        
        public Decimal PaidAmount { get; set; }

        
        public Int64 CostCategoryId { get; set; }

        
        public Int64 ProjectId { get; set; }

        
        public String CurrentStatus { get; set; }

        
        public String ContractType { get; set; }

        
        public String Scope { get; set; }

        
        public Int64 VendorId { get; set; }

        
        public Int64 PaymentTerms { get; set; }

        
        public String TaxName { get; set; }

        
        public Decimal TaxRate { get; set; }
    }
}
