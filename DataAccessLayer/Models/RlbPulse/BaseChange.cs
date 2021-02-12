using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class BaseChange
    {
            [Key]
            public Int64 BaseChangeId { get; set; }

  
            public String ChangeDescription { get; set; }


            public String ChangeType { get; set; }

            
            public Decimal ChangeAmount { get; set; }

            
            public Int64 ChangeDuration { get; set; }

            
            public Int64 ChangeParentId { get; set; }

            
            public Int64 HistoricalEntityId { get; set; }

            
            public Int64 ReportingPeriodId { get; set; }

            
            public Int64 PayableItemId { get; set; }

            
            public String ChangeImpact { get; set; }

            
            public String CurrentStatus { get; set; }

            
            public Int64 ContractId { get; set; }

            
            public Int64 ProjectId { get; set; }

        }
    }
