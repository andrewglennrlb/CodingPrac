using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ContractItem
    {
        [Key]
        public Int64 ContractItemId { get; set; }

        public String ItemType { get; set; }


        public Int64 ContractId { get; set; }


        public Decimal EstimatedAmount { get; set; }


        public Decimal CurrentAmount { get; set; }


        public Int64 PayableemId { get; set; }


        public String Description { get; set; }


        public Int64 StandardItemId { get; set; }
    }
}
