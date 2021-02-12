using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class PayableItem
    {
        [Key]
        public int PayableItemId { get; set; }


        public int ForeignId { get; set; }


        public decimal CurrentPaidAmount { get; set; }


        public decimal PaidPercentage { get; set; }


        public string ForeignType { get; set; }
    }
}
