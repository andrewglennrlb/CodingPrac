using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class HistoricalEntity
    {
        [Key]
        public int HistoricalEntityId { get; set; }


        public int ForeignId { get; set; }


        public int ForeignEntityType { get; set; }


        public int CurrentEntryId { get; set; }


        public int PreviousEntryId { get; set; }


        public string EntityTitle { get; set; }
    }
}
