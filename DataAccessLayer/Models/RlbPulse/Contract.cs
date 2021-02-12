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

        
        public string ContractDescription { get; set; }

        
        public Int64 ReportingPeriodId { get; set; }

        
        public Int64 HistoricalEntityId { get; set; }

        
        public Decimal CurrentAmount { get; set; }

        
        public Decimal PaidAmount { get; set; }

        
        public Int64 CostCategoryId { get; set; }

        
        public Int64 ProjectId { get; set; }

        
        public string CurrentStatus { get; set; }

        
        public string ContractType { get; set; }

        
        public string Scope { get; set; }

        
        public Int64 VendorId { get; set; }

        
        public Int64 PaymentTerms { get; set; }

        
        public string TaxName { get; set; }

        
        public decimal TaxRate { get; set; }
    }
}
