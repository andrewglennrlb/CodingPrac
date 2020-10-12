using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class HistoricalEntry
    {
        [Key]
        public int HistoricalEntryId { get; set; }


        public int HistoricalEntityId { get; set; }

        public string PreviousStatus { get; set; }

        public decimal? PreviousAmount { get; set; }


        public int Version { get; set; }


        public int ReportingPeriodId { get; set; }


        public byte[] Changes { get; set; }


        public int UserId { get; set; }


        public string ChangeTimestamp { get; set; }
    }
}
