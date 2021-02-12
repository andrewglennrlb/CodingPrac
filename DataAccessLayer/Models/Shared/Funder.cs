using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Funder
    {
        [Key]
        public Int64 FunderId { get; set; }


        public Int64 FunderName { get; set; }


        public Int64 OrgGroupId { get; set; }


        public Decimal FunderBudget { get; set; }


        public String FunderCurrency { get; set; }

    }
}
